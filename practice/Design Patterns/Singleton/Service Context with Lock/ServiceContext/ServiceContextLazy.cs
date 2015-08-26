using System;
using System.Threading;

namespace Epam.NetMentoring.ServiceContext
{
    public sealed class ServiceContextLazy
    {
        private static readonly Lazy<ServiceContextLazy> instance =
            new Lazy<ServiceContextLazy>(() => new ServiceContextLazy());

        private ServiceContextLazy()
        {
        }

        public static ServiceContextLazy GetInstance
        {
            get { return instance.Value; }
        }

        public void GetHash()
        {
            Console.WriteLine("Hashcode of object is '{0}', running in thread '{1}'", instance.GetHashCode(),
                Thread.CurrentThread.ManagedThreadId);
        }
    }
}