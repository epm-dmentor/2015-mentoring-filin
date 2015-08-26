using System;
using System.Threading;

namespace Epam.NetMentoring.ServiceContext
{
    public sealed class ServiceContext
    {
        private static ServiceContext instance;
        private static readonly object SyncObj = new object();

        private ServiceContext()
        {
        }

        public static ServiceContext GetInstance
        {
            get
            {
                if (instance == null)

                    //BK: this is wrong implementation. Please review this and answer why it is wrong.
                    //AF: corrected
                    lock (SyncObj)
                    {
                        if (instance == null)
                        {
                            instance = new ServiceContext();
                        }
                    }
                return instance;
            }
        }

        public void GetHash()
        {
            Console.WriteLine("Hashcode of object is '{0}', running in thread '{1}'", instance.GetHashCode(),
                Thread.CurrentThread.ManagedThreadId);
        }
    }
}