using System.Collections.Generic;

namespace Epam.NetMentoring.Patterns.Observer
{
    class EventRaiser : ISubject
    {
        private readonly List<ISubscriber> observers;
        private readonly string eventDetails;

        public EventRaiser(string eventDetails)
        {
            observers = new List<ISubscriber>();
            this.eventDetails = eventDetails;
        }

        public void Attach(ISubscriber observer)
        {
           observers.Add(observer);
        }

        public void Detach(ISubscriber observer)
        {
            //Why do you need that? Can't u use only Remove?
            int i = observers.IndexOf(observer);

            if (i >= 0)
            {
                observers.Remove(observer); 
            }
            
        }

        public void Notify()
        {
            foreach (ISubscriber observer in observers)
            {
                observer.Update(eventDetails);
            }
        }
    }
}
