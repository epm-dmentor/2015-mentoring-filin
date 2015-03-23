#region

using System;
using System.Threading;

#endregion

namespace Epam.NetMentoring.Zoo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Logger.Log("Starting program");

            var thread = new Thread(() =>
            {
                var zoo = new Zoo();
                EarthLiveTicker.LiveTicker.Subscribe(zoo);
                var animalProvider = new AnimalProvider(zoo);
                EarthLiveTicker.LiveTicker.Subscribe(animalProvider);
            });
            thread.Start();

            Logger.Log("Animan provider started working");
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}