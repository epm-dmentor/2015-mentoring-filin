using System;
using System.Threading;

namespace Epam.Mentoring.Patterns.Observer.StockExchange
{
    class StockMarketing
    {
        private event EventHandler<StockDetailsEventArgs> PriceChanged;
        private readonly Stock stock;

        public StockMarketing(Stock stock)
        {
            this.stock = stock;
        }

        
        //Trigger the start of trading
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
            if (PriceChanged == null) return;
            var args = new StockDetailsEventArgs { StockPrice = currentPrice };
            Console.WriteLine("{0}'s current price is {1}", stock.Name, args.StockPrice);

            PriceChanged(this, args);
        }

        public void Attach(IInvestor observer)
        {
            PriceChanged += observer.StockPriceChanged;
        }

        public void Deattach(IInvestor observer)
        {
            PriceChanged -= observer.StockPriceChanged;
        }
    }
}
