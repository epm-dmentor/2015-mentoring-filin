namespace Epam.NetMentoring.Patterns.Observer.StockExchange_on_Interfaces
{
    interface IObservable
    {
        void Attach(IObserver observer);
        void Deattach(IObserver observer);
    }
}
