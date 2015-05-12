namespace Epam.NetMentoring.Patterns.Observer.StockExchangeOnDelegates
{
    interface IObserver
    {
        void StockPriceChanged(double stockPrice);
    }
}
