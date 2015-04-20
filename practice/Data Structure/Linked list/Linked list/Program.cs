using System;

namespace Epam.NetMentoring.DataStructures.LinkedList
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var random = new Random();
            var list = new LinkedList();
            for (var i = 0; i < 3; i++)
            {
                list.Add(random.Next(i, 10));
            }

            Console.Write(list);
            Console.WriteLine("Total added: " + list.Count + Environment.NewLine);
            Console.WriteLine("Adding Element with value 2 at index \"0\":");
            list.AddAt(0, 2);
            Console.Write(list);
            Console.WriteLine("Total: " + list.Count + Environment.NewLine);

            Console.WriteLine("Removing Element with value \"2\":");
            list.Remove(2);
            Console.Write(list);
            Console.WriteLine("Total: " + list.Count + Environment.NewLine);
            Console.WriteLine("Removing Element at index \"0\":");
            list.RemoveAt(0);
            Console.Write(list);
            Console.WriteLine("Total: " + list.Count + Environment.NewLine);
            Console.ReadKey();
        }
    }
}