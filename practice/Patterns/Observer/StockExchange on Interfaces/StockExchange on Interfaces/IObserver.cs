namespace Epam.NetMentoring.Patterns.Observer.StockExchange_on_Interfaces
{
    internal interface IObserver
    {
        void StockPriceChanged(double stockPrice);
    }
}

