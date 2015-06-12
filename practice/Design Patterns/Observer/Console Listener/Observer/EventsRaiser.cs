using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Patterns.Observer
{
    class EventRaiser //: ISubject
    {
        public static event EventHandler<UpdatedEventArgs> ConsoleUpdated;

        public static void CheckingConsole()
        {
            while (true)
            {
                var getString = Console.ReadLine();
                RaiseEvent(getString);
            }
        }

        private static void RaiseEvent(string message)
        {
            EventHandler<UpdatedEventArgs> handler = ConsoleUpdated;
            if (handler != null)
            {
                handler(typeof(EventRaiser), new UpdatedEventArgs(message));
            }
        }

        //private readonly List<ISubscriber> observers;
        //private readonly string eventDetails;

        //public EventRaiser(string eventDetails)
        //{
        //    observers = new List<ISubscriber>();
        //    this.eventDetails = eventDetails;
        //}

        //public void Attach(ISubscriber observer)
        //{
        //   observers.Add(observer);
        //}

        //public void Detach(ISubscriber observer)
        //{
        //    //Why do you need that? Can't u use only Remove?
        //    int i = observers.IndexOf(observer);

        //    if (i >= 0)
        //    {
        //        observers.Remove(observer); 
        //    }
            
        //}

        //public void Notify()
        //{
        //    foreach (ISubscriber observer in observers)
        //    {
        //        observer.Update(eventDetails);
        //    }
        //}

       
    }
}
