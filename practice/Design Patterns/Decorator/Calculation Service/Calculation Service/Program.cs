#region

using System;
using System.Diagnostics;

#endregion

namespace Epam.Mentoring.Patterns.Decorator.CalculationService
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConsoleKey key;
            var calc = new CachedCalculationService(new CalculationService());
            var calcCorrection = new CorrectedCalculationService(calc);
            var watch1 = new Stopwatch();
            var watch2 = new Stopwatch();
            do
            {
                Console.Clear();
                Console.WriteLine("Calculate 2 numbers using cache\n");
                Console.WriteLine("Please enter first number:");
                var num1 = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Please enter second number:");
                var num2 = Convert.ToDecimal(Console.ReadLine());

                watch1.Reset();
                watch2.Reset();
                watch1.Start();
                var result1 = calc.Calculate(num1, num2);
                watch1.Stop();
                watch2.Start();
                var result2 = calcCorrection.Calculate(num1, num2);
                watch2.Stop();

                Console.WriteLine("Result of calculation is {0}, elapsed time: {1} milliseconds", result1,
                    watch1.Elapsed.TotalMilliseconds);
                Console.WriteLine("Result of calculation with correction is {0}, elapsed time: {1} milliseconds", result2,
                    watch1.Elapsed.TotalMilliseconds + watch2.Elapsed.TotalMilliseconds);
                Console.WriteLine("\n\n\n\nPress Esc to exit");
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Escape);
        }
    }
}