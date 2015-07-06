using System;

namespace Epam.Mentoring.Patterns.Decorator.Calculator
{
    internal class Program
    {
        //BK: That is quite good. Please implement task b) and ignore task c). We will come back to injection later
        private static void Main(string[] args)
        {
            

            //(10+2)*8/6-6 = 10
            var result = new Minus(
                new Divide(
                    new Multiply(
                        new Add(new Number(10), new Number(2)), new Number(8)), new Number(6)), new Number(6)).Calculate();
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}