using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.DesignPatterns.Adapter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var lists = new List<string>
            {
                "jiojo",
                "hyguygk",
                "uhg87tu8"
            };

            var adaptee = new Elements(lists);
            var adapter = new Container(adaptee);
            var printer = new Printer();

            printer.Print(adapter);

            Console.ReadKey();
        }
    }
}