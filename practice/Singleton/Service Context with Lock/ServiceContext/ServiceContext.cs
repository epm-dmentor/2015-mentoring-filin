namespace Epam.NetMentoring.ServiceContext
{
    public sealed class ServiceContext
    {
        private static ServiceContext instance;
        private static readonly object SyncObj = new object();

        private ServiceContext() { }

        public static ServiceContext GetInstance()
        {
            if (instance != null) return instance;

            lock (SyncObj)
            {
                instance = new ServiceContext();
            }
            return instance;
        }

    }
}
