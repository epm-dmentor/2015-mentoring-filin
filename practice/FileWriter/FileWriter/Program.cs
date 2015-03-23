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

            fileWrite.Write("First test string2");
            fileWrit.Write("First test string3");
            fileWrite.Write("First test string5");
            fileWriter.Write("First test string8");

            Console.ReadKey();
        }
    }
}
