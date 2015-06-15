using System;

namespace Epam.NetMentoring.Patterns.Observer
{
    internal class MessageDisplaySubscriber : ISubscriber
    {
        public void Update(string eventDetails)
        {
            Console.WriteLine("You've typed - " + eventDetails);
        }
    }
}