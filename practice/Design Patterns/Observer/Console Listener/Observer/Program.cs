﻿using System;
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

        
        //AF: Updated
        static void Main(string[] args)
        {
            Console.WriteLine("Type something to update console:");

            ISubject raiseEvent = new EventRaiser();
            ISubscriber onQuit = new QuitSubscriber();
            ISubscriber displayMessage = new MessageDisplaySubscriber();
            ISubscriber logger = new LoggerSubscriber();

            raiseEvent.Attach(onQuit);
            raiseEvent.Attach(displayMessage);
            raiseEvent.Attach(logger);

            raiseEvent.CheckingConsole();
            
        }
    }
}
