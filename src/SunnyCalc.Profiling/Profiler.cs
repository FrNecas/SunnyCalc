using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using SunnyCalc.Maths;

namespace SunnyCalc.Profiling
{
    /// <summary>
    /// The <see cref="Profiler"/> class provides an implementation of a standard deviation calculation algorithm,
    /// which can be used to profile the performance of a supplied <see cref="IMathsService"/> implementation.
    /// It also contains a simple integrated profiling mechanism.
    /// A <see cref="Profiler"/> instance can then also be used in profiling mode, where calls to the <see cref="IMathsService"/>
    /// are sampled and a log about their average run time.
    /// A <see cref="Profiler"/> instance holds a list of <see cref="double"/> values used in the calculation. These
    /// values can be read from a file, a <see cref="TextReader"/> or supplied directly as an enumerable. 
    /// It can be configured to run in the profiling mode by calling one of the UseSummary method overloads.
    /// </summary>
    public class Profiler : IDisposable
    {
        private class Measurement
        {
            public long TotalMilliseconds { get; set; }
            public long TotalTicks { get; set; }
            public int Samples { get; set; }


            public override string ToString()
            {
                return
                    $"{TotalMilliseconds / (double) Samples} ms | {TotalTicks / (Samples * TicksPerUs)} μs, used {Samples} samples";
            }
        }

        private readonly IMathsService _mathsService;

        private List<double> _doubleValues;
        private readonly Dictionary<string, Measurement> _categoryMeasurements = new Dictionary<string, Measurement>();

        private StreamWriter _outputWriter;
        private TextReader _inputReader;
        private Stopwatch _stopwatch;

        private bool HasOutput => _outputWriter != null;
        private static readonly double TicksPerUs = Stopwatch.Frequency / (1000.0 * 1000.0);

        public Profiler(IMathsService mathsService)
        {
            _mathsService = mathsService;
        }

        /// <summary>
        /// Configures this <see cref="Profiler"/> instance to enable the internal profiling
        /// and to output the profiling summary/logs to the specified file. The file is overwritten.
        /// If <paramref name="fileName"/> is null, the method does nothing and the configuration is kept in its previous state.
        /// </summary>
        /// <param name="fileName">The path of the file to save the profiling output to.</param>
        public void UseSummary(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return;

            _outputWriter?.Dispose();
            _outputWriter = new StreamWriter(fileName, false, Encoding.UTF8);
        }

        /// <summary>
        /// Configures this <see cref="Profiler"/> instance to enable the internal profiling
        /// and to output the profiling summary/logs to the specified stream.
        /// </summary>
        /// <param name="stream">The stream to save the profiling output to.</param>
        public void UseSummary(Stream stream)
        {
            _outputWriter?.Dispose();

            if (stream == null)
            {
                _outputWriter = null;
                return;
            }

            _outputWriter = new StreamWriter(stream, Encoding.UTF8);
        }

        /// <summary>
        /// Configures this <see cref="Profiler"/> instance to read the values used for calculation
        /// from the specified file.
        /// Discards any other input sources set by different overloads of this method.
        /// </summary>
        /// <param name="fileName">The path of the file to load the values from.</param>
        /// <seealso cref="ReadInput"/>
        public void UseInput(string fileName)
        {
            _inputReader?.Dispose();
            _inputReader = new StreamReader(fileName);
        }

        /// <summary>
        /// Configures this <see cref="Profiler"/> instance to read the values used for calculation
        /// from the specified <see cref="TextReader"/> object.
        /// Discards any other input sources set by different overloads of this method.
        /// </summary>
        /// <param name="reader">The reader to read the values from.</param>
        /// <seealso cref="ReadInput"/>
        public void UseInput(TextReader reader)
        {
            _inputReader?.Dispose();
            _inputReader = reader;
        }

        /// <summary>
        /// Replaces the internal list of values used for calculation with values taken from the enumerable <paramref name="values"/>.
        /// Discards any other input sources set by different overloads of this method.
        /// </summary>
        /// <param name="values">The enumerable to copy the values from.</param>
        /// <seealso cref="ReadInput"/>
        public void UseInput(IEnumerable<double> values)
        {
            _inputReader?.Dispose();
            _doubleValues = new List<double>(values);
        }

        /// <summary>
        /// Reads the configured values source, performs the calculations and returns the calculated standard deviation.
        /// </summary>
        /// <remarks>
        /// If this <see cref="Profiler"/> instance has been configured to work in the profiler mode using one of the
        /// UseSummary overloads, the <see cref="CalculateDoublesWithProfiling"/> and <see cref="CalculateExpressionWithProfiling"/>
        /// methods are called and the calls to different mathematical operations are profiled. The profiling results are saved
        /// to the configured summary/log output.
        /// If it is not, only <see cref="CalculateDoubles"/> is called and the standard deviation value is returned.
        /// </remarks>
        /// <returns>A standard deviation value. -1 if the values source is empty.</returns>
        public double Run()
        {
            if (!this.ReadInput())
            {
                return -1;
            }

            if (this.HasOutput)
            {
                double result = 0;
                _stopwatch = new Stopwatch();
                _stopwatch.Start();
                this.Log("Beginning.");
                this.Log("Running classic calculations profiling");
                this.ProfileActionTime(() => result = CalculateDoubles(), nameof(CalculateDoubles));
                this.Log("Running profiled classic calculations profiling");
                this.ProfileActionTime(CalculateDoublesWithProfiling, nameof(CalculateDoublesWithProfiling));
                this.Log("Running expression solver profiling");
                this.ProfileActionTime(CalculateExpressionWithProfiling, nameof(CalculateExpressionWithProfiling));
                _outputWriter.WriteLine("-------------------------------------------------------\n\nCategory reports:");

                foreach (var m in _categoryMeasurements)
                {
                    _outputWriter.WriteLine($"[{m.Key}]: {m.Value}");
                }

                _outputWriter.WriteLine();
                this.Log("Finished.");

                return result;
            }

            return this.CalculateDoubles();
        }

        /// <summary>
        /// Reads the input configured using <see cref="UseInput(string)"/> or <see cref="UseInput(TextReader)"/>.
        /// The reader reads the source until the <see cref="TextReader"/> returns null, e.g. when it reaches EOF.
        /// It expects one number per line.
        /// Lines with no number parseable with <see cref="double.TryParse(string,out double)"/> are quietly ignored.
        /// If the input was last set using <see cref="UseInput(IEnumerable{double})"/>, this method does nothing.
        /// </summary>
        /// <returns>True if the values list now contains at least one number.</returns>
        private bool ReadInput()
        {
            if (_doubleValues == null) _doubleValues = new List<double>();

            if (_inputReader != null)
            {
                string line = null;

                while ((line = _inputReader.ReadLine()) != null)
                {
                    if (double.TryParse(line, out var n))
                    {
                        _doubleValues.Add(n);
                    }
                }
            }

            return _doubleValues.Count > 0;
        }

        /// <summary>
        /// Calculates the standard deviation of the set of values currently kept by this <see cref="Profiler"/> instance.
        /// </summary>
        /// <remarks>
        /// This method is primarily used for the basic running mode of this program.
        /// It doesn't trigger any integrated profiling.
        /// </remarks>
        /// <returns>The standard deviation.</returns>
        private double CalculateDoubles()
        {
            double avg = 0;
            double squareSum = 0;

            foreach (var x in _doubleValues)
            {
                avg = _mathsService.Add(avg, x);
                var xSq = _mathsService.Power(x, 2);
                squareSum = _mathsService.Add(squareSum, xSq);
            }

            avg = _mathsService.Divide(avg, _doubleValues.Count);
            avg = _mathsService.Power(avg, 2);
            avg = _mathsService.Multiply(_doubleValues.Count, avg);

            var top = _mathsService.Subtract(squareSum, avg);
            var btm = _mathsService.Subtract(_doubleValues.Count, 1);
            var variance = _mathsService.Divide(top, btm);
            var deviation = _mathsService.Root(variance, 2);

            return deviation;
        }

        /// <summary>
        /// Calculates the standard deviation of the set of values currently kept by this <see cref="Profiler"/> instance.
        /// Measures the time of all performed mathematical operations by wrapping them in a <see cref="ProfileActionTime"/> call.
        /// </summary>
        /// <remarks>
        /// This method is primarily used for the profiler running mode of this program.
        /// It is used for measuring the duration of the methods of the current <see cref="IMathsService"/> implementation.
        /// The algorithm is the same as in <see cref="CalculateDoubles"/>.
        /// </remarks>
        /// <seealso cref="CalculateDoubles"/>
        /// <returns>The standard deviation.</returns>
        private double CalculateDoublesWithProfiling()
        {
            double avg = 0;
            double squareSum = 0;

            foreach (var x in _doubleValues)
            {
                var currentAvg = avg;
                avg = this.ProfileActionTime(() => _mathsService.Add(currentAvg, x), null, "Add");

                var xSq = this.ProfileActionTime(() => _mathsService.Power(x, 2), null, "Power");
                var sum = squareSum;
                squareSum = this.ProfileActionTime(() => _mathsService.Add(sum, xSq), null, "Add");
            }

            // The current value of avg is saved in a temporary variable, because updating a variable
            // that is passed in a lambda closure with a result of the lambda might lead to unexpected results.
            var avg1 = avg;
            avg = this.ProfileActionTime(() => _mathsService.Divide(avg1, _doubleValues.Count), null, "Divide");

            var avg2 = avg;
            avg = this.ProfileActionTime(() => _mathsService.Power(avg2, 2), null, "Power");

            var avg3 = avg;
            avg = this.ProfileActionTime(() => _mathsService.Multiply(_doubleValues.Count, avg3), null, "Multiply");

            var top = this.ProfileActionTime(() => _mathsService.Subtract(squareSum, avg), null, "Subtract");
            var btm = this.ProfileActionTime(() => _mathsService.Subtract(_doubleValues.Count, 1), null, "Subtract");
            var variance = this.ProfileActionTime(() => _mathsService.Divide(top, btm), null, "Divide");
            var deviation = this.ProfileActionTime(() => _mathsService.Root(variance, 2), null, "Root");

            this.Log($"Standard calculation result: {deviation}");
            return deviation;
        }

        /// <summary>
        /// Assembles a mathematical expression used for calculating the deviation using the values currently
        /// kept by this <see cref="Profiler"/> instance and performs the calculation using <see cref="IMathsService.SolveExpression"/>,
        /// measuring the time it takes.
        /// </summary>
        /// <returns>The standard deviation.</returns>
        private double CalculateExpressionWithProfiling()
        {
            var avgSb = new StringBuilder();
            var sqSumSb = new StringBuilder();
            string expr = null;

            this.ProfileActionTime(() =>
            {
                avgSb.Append('(');
                foreach (var x in _doubleValues)
                {
                    avgSb.Append(x);
                    avgSb.Append('+');
                    sqSumSb.Append(x);
                    sqSumSb.Append("^2+");
                }

                avgSb.Length--; // Remove the last +
                sqSumSb.Length -= 3; // Remove the last ^2+

                avgSb.Append(")/");
                avgSb.Append(_doubleValues.Count);

                expr = $"sqrt(({sqSumSb}-{_doubleValues.Count}*({avgSb})^2)/({_doubleValues.Count}-1))";
            }, "Expression Composition");

            if (expr.Length > 90)
            {
                this.Log($"Using expression: {expr.Substring(0, 42)}...{expr.Substring(expr.Length - 42)}");
            }
            else
            {
                this.Log("Using expression: " + expr);
            }


            var result = this.ProfileActionTime(() => _mathsService.SolveExpression(expr), "Expression Solving",
                "Expression Solving");

            this.Log($"Expression solver result: {result}");
            return result;
        }

        private void ProfileActionTime(Action action, string name = null, string category = null)
        {
            this.ProfileActionTime(() =>
            {
                action();
                return 0;
            }, name, category);
        }

        /// <summary>
        /// Measures the time taken by calling <paramref name="action"/>.
        /// </summary>
        /// <remarks>
        /// If <paramref name="category"/> is not null, adds the taken sample to the corresponding measurement category.
        /// If <paramref name="name"/> is not null, the measurement is logged using <see cref="Log"/>.
        /// </remarks>
        /// <param name="action">The action to measure the time of.</param>
        /// <param name="name">The name of this measurement, used for logging purposes.</param>
        /// <param name="category">The category of the measurement (e.g. measured method name).</param>
        /// <seealso cref="Run"/>
        /// <seealso cref="Log"/>
        /// <typeparam name="T">The return type of <paramref name="action"/>.</typeparam>
        /// <returns>The return value of <paramref name="action"/>.</returns>
        private T ProfileActionTime<T>(Func<T> action, string name = null, string category = null)
        {
            if (name != null) this.Log($"Running '{name}'.");

            var time = _stopwatch.ElapsedMilliseconds;
            var ticks = _stopwatch.ElapsedTicks;
            var ret = action();
            time = _stopwatch.ElapsedMilliseconds - time;
            ticks = _stopwatch.ElapsedTicks - ticks;

            if (name != null) this.Log($"Finished '{name}'. Took {time} ms ({ticks / TicksPerUs} μs).");

            if (category != null)
            {
                if (!_categoryMeasurements.ContainsKey(category))
                {
                    _categoryMeasurements.Add(category, new Measurement());
                }

                var m = _categoryMeasurements[category];
                m.TotalMilliseconds += time;
                m.TotalTicks += ticks;
                m.Samples++;
            }

            return ret;
        }

        /// <summary>
        /// If this <see cref="Profiler"/> instance has a summary/logging output configured,
        /// appends a line with the time passed since profiling has started and <paramref name="message"/> to the output stream. 
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <seealso cref="Run"/>
        /// <seealso cref="UseSummary(string)"/>
        /// <seealso cref="UseSummary(Stream)"/>
        private void Log(string message)
        {
            if (this.HasOutput)
            {
                _outputWriter.WriteLine($"[{_stopwatch.ElapsedMilliseconds / 1000d:F2}] {message}");
            }
        }

        public void Dispose()
        {
            _outputWriter?.Dispose();
            _inputReader?.Dispose();
        }
    }
}
