using System;

namespace Epam.NetMentoring
{
    //BK: not optimal Disposal of resources here. Please have a look closer
    //F: I updated the code to use only one instance of MemoryStreamLogger and disposed it after iteration completed
    internal class Program
    {
        private static readonly MemoryStreamLogger Logger = new MemoryStreamLogger();
        private static void Main(string[] args)
        {
     
            for(var i = 0; i < 10000; i++)
                WriteLog("Interation number #" + i);
            Logger.Dispose();
            Console.WriteLine("Finished");
            Console.ReadKey();
            
        }
        private static void WriteLog(string str)
        {
            //using (var logger = new MemoryStreamLogger())
            //{
            //    logger.Log(str);
            //}
            Logger.Log(str);
        }


    }
}