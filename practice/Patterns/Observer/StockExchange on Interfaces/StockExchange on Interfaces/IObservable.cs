namespace Epam.NetMentoring.Patterns.Observer.StockExchangeOnInterfaces
{
    interface IObservable
    {
        void Attach(IObserver observer);
        void Deattach(IObserver observer);
    }
}
