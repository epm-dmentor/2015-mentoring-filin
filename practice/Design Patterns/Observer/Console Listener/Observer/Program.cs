using System;

namespace Epam.NetMentoring.Patterns.Observer
{
    class Program
    {
        //BK: You have implemented your pattern completely wrong. Please review that task one more time. What is the purpose of EventRaiser in your case? Please read the task one more time - you ned to add an event to your observer.
        //BK: Extending this tasks Please write: observer which terninates console (reacts only to quit command), observer which writes all messages to console and the third one which writes to txt log. 
        static void Main(string[] args)
        {
            Console.WriteLine("To raise event type \"quit\"");

            var er = new EventRaiser("You've been typed \"quit\"");
            var subscriber = new Sub();

            er.Attach(subscriber);

            string getString = Console.ReadLine();
            //BK: This logic should be incorporated into one of observer classes. Why is it here?
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
