using System;

namespace Epam.NetMentoring.Unmanaged
{
    class Program
    {
        private static void Main(string[] args)
        {
            //BK: This is more up toi you, but I would recommend to use { and } for using. But this is not smth critical, just a matter of preferences of every developer. For me thus code becomes more readable. 
            var fileWriter = new FileWriter("log.txt");
            var fileWrite = new FileWriter("log.txt");
            var fileWrit = new FileWriter("log.txt");

            fileWrite.Write("First test string");
            fileWrit.Write("First test string");
            fileWrite.Write("First test string");
            fileWriter.Write("First test string");

            Console.ReadKey();
        }
    }
}
