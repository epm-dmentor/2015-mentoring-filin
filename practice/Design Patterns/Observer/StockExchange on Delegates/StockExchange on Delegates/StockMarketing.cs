using System;
using System.Threading;

namespace Epam.NetMentoring.Patterns.Observer.StockExchangeOnDelegates
{
    class StockMarketing
    {
        private readonly Stock stock;
        public delegate void PriceChanged(double price);
        public PriceChanged PriceChangedEvent { get; set; }

        public StockMarketing(Stock stock)
        {
            this.stock = stock;
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
            if (PriceChangedEvent == null) return;
            Console.WriteLine("{0}'s current price is {1}", stock.Name, currentPrice);
            PriceChangedEvent(currentPrice);
        }

        //public void Attach(IObserver observer)
        //{

        //    changed += observer.StockPriceChanged;
        //}

        //public void Deattach(IObserver observer)
        //{
        //    changed -= observer.StockPriceChanged;
        //}
    }
}
