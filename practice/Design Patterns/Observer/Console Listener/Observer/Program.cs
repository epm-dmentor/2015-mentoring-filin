using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Epam.NetMentoring.Patterns.Observer
{
    class Program
    {
        //BK: You have implemented your pattern completely wrong. 
        //Please review that task one more time. What is the purpose of EventRaiser in your case? 
        //Please read the task one more time - you ned to add an event to your observer.
        //BK: Extending this tasks Please write: observer which terninates console (reacts only to quit command), observer which writes all messages to console and the third one which writes to txt log. 

        
        //AF: I hope that's what needed
        static void Main(string[] args)
        {
            var stream = new FileStream("./log.txt", FileMode.Create);

            Console.WriteLine("To raise event type \"quit\"");

            EventRaiser.ConsoleUpdated += (sender, eventArgs) =>
            {
                if (eventArgs.Message == "quit")
                {
                    Console.WriteLine("You've typed \"quit\"");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                Console.WriteLine("You've typed - " + eventArgs.Message);
                var result = Encoding.Default.GetBytes(eventArgs.Message + Environment.NewLine);
                stream.Write(result, 0, result.Length);
            };

            EventRaiser.CheckingConsole();


            //var er = new EventRaiser("You've been typed \"quit\"");
            //var subscriber = new Sub();

            //er.Attach(subscriber);

            //string getString = Console.ReadLine();
            ////BK: This logic should be incorporated into one of observer classes. Why is it here?
            //while (getString != "quit")
            //{
            //    getString = Console.ReadLine(); 
            //}

            //er.Notify();
            //er.Detach(subscriber);

            //Console.ReadKey();
        }
    }
}
