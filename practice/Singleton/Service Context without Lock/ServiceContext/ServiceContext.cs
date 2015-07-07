namespace Epam.NetMentoring.ServiceContext
{
    public sealed class ServiceContext
    {
        private static readonly ServiceContext Instance = new ServiceContext();

        private ServiceContext() { }

        static ServiceContext() { }

        public static ServiceContext GetInstance()
        {
            return Instance;
        }

    }
}
