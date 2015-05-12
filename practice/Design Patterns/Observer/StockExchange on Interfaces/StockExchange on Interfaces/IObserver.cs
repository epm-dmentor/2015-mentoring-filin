namespace Epam.NetMentoring.Patterns.Observer.StockExchangeOnInterfaces
{
    interface IObserver
    {
        void StockPriceChanged(double stockPrice);
    }
}

