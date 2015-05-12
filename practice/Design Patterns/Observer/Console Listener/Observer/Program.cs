using System;

namespace Epam.NetMentoring.Patterns.Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To raise event type \"quit\"");

            var er = new EventRaiser("You've been typed \"quit\"");
            var subscriber = new Sub();

            er.Attach(subscriber);

            string getString = Console.ReadLine();

            while (getString != "quit")
            {
                getString = Console.ReadLine(); 
            }

            er.Notify();
            er.Detach(subscriber);
            
            Console.ReadKey();
        }
    }
}
