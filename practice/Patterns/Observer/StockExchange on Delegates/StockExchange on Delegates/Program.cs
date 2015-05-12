using System;

namespace Epam.NetMentoring.Patterns.Observer.StockExchangeOnDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock epam = new Stock("epam", 14.00, 7.00);
            StockMarketing market = new StockMarketing(epam);
            IObserver alex = new Investor("Alex", 12.00, epam);
            IObserver mark = new Investor("Mark", 11.00, epam);

            market.Attach(alex);
            market.Attach(mark);

            market.OpeningTenders();
            market.Deattach(alex);
            Console.ReadKey();
        }
    }
}
