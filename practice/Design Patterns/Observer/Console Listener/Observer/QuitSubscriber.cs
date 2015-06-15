using System;

namespace Epam.NetMentoring.Patterns.Observer
{
    class QuitSubscriber : ISubscriber
    {
        public void Update(string eventDetails)
        {
            if (eventDetails != "quit") return;
            Console.WriteLine("You've typed \"quit\"");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
