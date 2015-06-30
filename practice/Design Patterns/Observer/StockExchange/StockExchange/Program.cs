using System;

namespace Epam.Mentoring.Patterns.Observer.StockExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock epam = new Stock("epam", 14.00, 7.00);
            StockMarketing market = new StockMarketing(epam);
            Investor alex = new Investor("Alex", 12.00, epam);
            Investor mark = new Investor("Mark", 11.00, epam);

            market.PriceChanged += alex.StockPriceChanged;
            market.PriceChanged += mark.StockPriceChanged;
            market.OpeningTenders();

            
            Console.ReadKey();
        }
    }
}
