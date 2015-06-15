using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Patterns.Observer
{
    class EventRaiser : ISubject
    {
        private readonly List<ISubscriber> observers;

        public EventRaiser()
        {
            observers = new List<ISubscriber>();
        }

        public void Attach(ISubscriber observer)
        {
            observers.Add(observer);
        }

        public void Detach(ISubscriber observer)
        {
            observers.Remove(observer);
        }

        public void CheckingConsole()
        {
            while (true)
            {
                string getString = Console.ReadLine();
                NotifySubcribers(getString);
            }
        }

        private void NotifySubcribers(string message)
        {
            foreach (ISubscriber observer in observers)
            {
                observer.Update(message);
            }
        }
    }
}
