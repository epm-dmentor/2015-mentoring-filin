using System;

namespace NetMentoring
{
    //BK: not optimal Disposal of resources here. Please have a look closer  
    internal class Program
    {
        private static void Main(string[] args)
        {
     
            for(var i = 0; i < 10000; i++)
                WriteLog("Interation number #" + i);

            Console.WriteLine("Finished");
            Console.ReadKey();
            
        }
        private static void WriteLog(string str)
        {
            using (var logger = new MemoryStreamLogger())
            {
                logger.Log(str);
            }
        }


    }
}