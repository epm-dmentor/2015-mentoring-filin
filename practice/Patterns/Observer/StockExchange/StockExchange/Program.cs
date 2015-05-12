using System;

namespace Epam.Mentoring.Patterns.Observer.StockExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock epam = new Stock("epam", 14.00, 7.00);
            StockMarketing market = new StockMarketing(epam);
            IInvestor alex = new Investor("Alex", 12.00, epam);
            IInvestor mark = new Investor("Mark", 11.00, epam);

            market.Attach(alex);
            market.Attach(mark);

            market.OpeningTenders();
            Console.ReadKey();
        }
    }
}
