using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Patterns.Factory.RetailEquity
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var trades = new List<Trade>
            {
                new Trade("Option", "NyOption", 24),
                new Trade("Future", "LdnFuture", 75),
                new Trade("Option", "SgpOption", 8)
            };

            var factory = new FilterFactory();
            IEnumerable<Trade> barclays = factory.Filter("Barclays").Comply(trades);
            IEnumerable<Trade> bofa = factory.Filter("Bofa").Comply(trades);
            IEnumerable<Trade> connacord = factory.Filter("Connacord").Comply(trades);

            Console.ReadKey();
        }
    }
}