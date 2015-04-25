using System;

namespace Epam.NetMentoring.DataStructures.HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable ht = new HashTable(10); //HashTable with fixed size
            ht.Add("1","fdgdgfdg");
            ht.Add("2","yuu");
            ht.Add("3","sfr");
            
            object test;
            Console.WriteLine(ht["1"]);

            Console.WriteLine(ht.Contains("4"));
            ht.TryGet("2", out test);
            Console.WriteLine(test);
            ht["1"] = null;
           
            Console.Read();
        }
    }
}
