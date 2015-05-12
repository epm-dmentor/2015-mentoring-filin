using System;

namespace Epam.NetMentoring.Patterns.Observer
{
    class Sub : ISubscriber
    {
        public void Update(string eventDetails)
        {
            Console.WriteLine(eventDetails);
        }
    }
}
