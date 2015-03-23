#region

using System;

#endregion

namespace NetMentoring.IDisposableImplementation
{
    //BK: not optimal Disposal of resources here. Please have a look closer
    //F: In this case I don't see much sense in WriteLog method at all. I would did the following: 
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (MemoryStreamLogger logger = new MemoryStreamLogger())
            {
                for (var i = 0; i < 10000; i++)
                    logger.Log("Interation number #" + i);
            }

            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}