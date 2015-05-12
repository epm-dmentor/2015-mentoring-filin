using System;
using System.Collections.Generic;
using System.Threading;

namespace Epam.NetMentoring.Patterns.Observer.StockExchangeOnInterfaces
{
    class StockMarketing : IObservable
    {
        private readonly IList<IObserver> investors;
        private readonly Stock stock;

        public StockMarketing(Stock stock)
        {
            this.stock = stock;
            investors = new List<IObserver>();
        }

        public void OpeningTenders()
        {
            if (stock == null)
            {
                throw new ArgumentException("Stock must be provided before trading is started");
            }

            double currentPrice = stock.StartPrice;

            //simulate the falling stock's price in the market
            //and notify investor when it's time to buy shares
            while (currentPrice > stock.ClosingPrice)
            {
                currentPrice -= 1.00;
                OnStockPriceChanged(currentPrice);
                Thread.Sleep(2000);
            }
        }

        private void OnStockPriceChanged(double currentPrice)
        {
            if (investors == null) return;
            Console.WriteLine("{0}'s current price is {1}", stock.Name, currentPrice);
            foreach (var investor in investors)
            {
                investor.StockPriceChanged(currentPrice);
            }
        }

        public void Attach(IObserver observer)
        {
            investors.Add(observer);
        }

        public void Deattach(IObserver observer)
        {
            int i = investors.IndexOf(observer);

            if (i >= 0)
            {
                investors.Remove(observer);
            }
        }
        
    }
}
