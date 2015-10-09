using System;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

namespace WCF_Service
{
    class Program
    {
        private static void Main(string[] args)
        {
            var service = new ServiceHost(typeof (JokeService));
            service.Open();

            Console.WriteLine("Press <ENTER> to exit.\n");
            Console.ReadKey();
        }
    }
}