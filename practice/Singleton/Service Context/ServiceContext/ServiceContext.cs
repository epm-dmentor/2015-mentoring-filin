namespace Epam.NetMentoring.ServiceContext
{
    public sealed class ServiceContext
    {
        private static ServiceContext instance;

        private ServiceContext() { }

        public static ServiceContext GetInstance()
        {
           return instance ?? (instance = new ServiceContext());
        }

    }
}
