using System;
using System.Threading;

namespace Epam.NetMentoring.ServiceContext
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            for (var i = 0; i < 10; i++)
            {
                //new Thread(() => ServiceContext.GetInstance.GetHash()).Start();
                new Thread(() => ServiceContextLazy.GetInstance.GetHash()).Start();
            }

            Console.ReadKey();
        }
    }
}