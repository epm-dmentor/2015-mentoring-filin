﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace SelfHostedSDesk
{
    class Program
    {
        static void Main(string[] args)
        {
            const string baseUri = "http://*:8080";
            Console.WriteLine("Starting web Server...");
            WebApp.Start<Startup>(baseUri);
            Console.WriteLine("Server running at {0} - press Enter to quit.", baseUri);
            Console.ReadLine();
        }
    }
}
