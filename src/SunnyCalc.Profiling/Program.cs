using System;
using System.Collections.Generic;
using System.Linq;
using SunnyCalc.Maths;

namespace SunnyCalc.Profiling
{
    class Program
    {
        static int Main(string[] args)
        {
            var mathsService = new MathsService();
            using var profiler = new Profiler(mathsService);

            var ac = 0;

            if (args.Length >= 2 && args[0] == "-s" && !string.IsNullOrWhiteSpace(args[1]))
            {
                if (args[1] == "-")
                {
                    profiler.UseSummary(Console.OpenStandardError());
                }
                else
                {
                    profiler.UseSummary(args[1]);
                }

                ac = 2;
            }

            if (args.Length >= (ac + 1) && !string.IsNullOrWhiteSpace(args[ac]))
            {
                profiler.UseInput(args[ac]);
            }
            else
            {
                profiler.UseInput(Console.In);
            }

            Console.WriteLine(profiler.Run());

            return 0;
        }
    }
}
