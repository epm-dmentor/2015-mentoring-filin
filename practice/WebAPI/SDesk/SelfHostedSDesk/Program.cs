using System;
using Microsoft.Owin.Hosting;

namespace SelfHostedSDesk
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string baseUri = "http://*:8080";
            Console.WriteLine("Starting web Server...");
            WebApp.Start<Startup>(baseUri);
            Console.WriteLine("Server running at {0} - press Enter to quit.", baseUri);
            Console.ReadLine();
        }
    }
}