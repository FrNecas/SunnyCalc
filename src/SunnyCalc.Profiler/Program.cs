using System;
using SunnyCalc.Maths;

namespace SunnyCalc.Profiler
{
    class Program
    {
        static void Main(string[] args)
        {
            var mathsService = new MathsService();
            using var profiler = new Profiler(mathsService);

            if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
            {
                profiler.UseSummaryFile(args[0]);
            }
            
            profiler.UseInput(Console.In);
            Console.WriteLine(profiler.Run());
        }
    }
}
