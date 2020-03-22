using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using SunnyCalc.Maths;

namespace SunnyCalc.Profiling
{
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

        public void UseSummary(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return;

            _outputWriter?.Dispose();
            _outputWriter = new StreamWriter(fileName, false, Encoding.UTF8);
        }

        public void UseSummary(Stream stream)
        {
            _outputWriter?.Dispose();
            _outputWriter = new StreamWriter(stream, Encoding.UTF8);
        }

        public void UseInput(string fileName)
        {
            _inputReader?.Dispose();
            _inputReader = new StreamReader(fileName);
        }
        
        public void UseInput(TextReader reader)
        {
            _inputReader?.Dispose();
            _inputReader = reader;
        }

        public void UseInput(IEnumerable<double> values)
        {
            _inputReader?.Dispose();
            _doubleValues = new List<double>(values);
        }

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

        private bool ReadInput()
        {
            if(_doubleValues == null) _doubleValues = new List<double>();
            
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

            return deviation;
        }

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

            return result;
        }

        private void ProfileActionTime(Action action, string name = null, string category = null)
        {
            if (name != null) this.Log($"Running '{name}'.");

            var time = _stopwatch.ElapsedMilliseconds;
            var ticks = _stopwatch.ElapsedTicks;
            action();
            time = _stopwatch.ElapsedMilliseconds - time;
            ticks = _stopwatch.ElapsedTicks - ticks;

            if (name != null) this.Log($"Finished '{name}'. Took {time} ms ({ticks / TicksPerUs} μs).");

            if (category != null)
            {
                if (_categoryMeasurements.ContainsKey(category))
                {
                    _categoryMeasurements.Add(category, new Measurement());
                }

                var m = _categoryMeasurements[category];
                m.TotalMilliseconds += time;
                m.TotalTicks += ticks;
                m.Samples++;
            }
        }

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
