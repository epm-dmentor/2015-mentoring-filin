#region

using System;

#endregion

namespace Epam.NetMentoring.Unmanaged
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //BK: This is more up toi you, but I would recommend to use { and } for using. But this is not smth critical, just a matter of preferences of every developer. For me thus code becomes more readable. 

            using (var fileWriter = new FileWriter("log.txt"))
            {
                fileWriter.Write("First test string");
            }

            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}