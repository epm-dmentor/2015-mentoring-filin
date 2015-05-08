using System;

namespace Epam.Mentoring.Patterns.Observer.StockExchange
{
    class Investor : IBidder
    {
        public string name;
        private double price;
        private Stock stock;
        private bool bought;

        public Investor(string name, double price, Stock stock)
        {
            this.name = name;
            this.price = price;
            this.stock = stock;

        }

        public void StockPriceChanged(object sender, StockDetailsEventArgs e)
        {
            if (e.StockPrice <= price && !bought)
            {
                Console.WriteLine("{0} is buying {1}'s stock at {2}", name,stock.Name,e.StockPrice);
                bought = true;
            }
        }
    }
}
