using System;

namespace Epam.NetMentoring.Patterns.Observer.StockExchangeOnDelegates
{
    class Investor : IObserver
    {
        public string name;
        private readonly double price;
        private readonly Stock stock;
        private bool bought;

        public Investor(string name, double price, Stock stock)
        {
            this.name = name;
            this.price = price;
            this.stock = stock;

        }

        public void StockPriceChanged(double stockPrice)
        {
            if (stockPrice <= price && !bought)
            {
                Console.WriteLine("{0} is buying {1}'s stock at {2}", name, stock.Name, stockPrice);
                bought = true;
            }
        }
    }
}
