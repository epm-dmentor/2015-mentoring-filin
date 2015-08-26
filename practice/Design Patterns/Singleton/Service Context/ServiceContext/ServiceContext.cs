namespace Epam.NetMentoring.ServiceContext
{
    public sealed class ServiceContext
    {
        private static ServiceContext instance;

        private ServiceContext()
        {
        }

        //BK: Use Property instead here
        public static ServiceContext GetInstance
        {
            get { return instance ?? (instance = new ServiceContext()); }
        }
    }
}