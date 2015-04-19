using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomHashTable ht = new CustomHashTable(10);
            ht.Add("1","fdgdgfdg");
            ht.Add("2","yuu");
            ht.Add("1", "sfr");

            object test;
            Console.WriteLine(ht["1"]);

            Console.WriteLine(ht.Contains("3"));
            ht.TryGet("1", out test);
            Console.WriteLine(test);
            Console.Read();
        }
    }
}
