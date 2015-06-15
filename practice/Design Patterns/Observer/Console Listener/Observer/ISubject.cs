namespace Epam.NetMentoring.Patterns.Observer
{
    interface ISubject
    {
        void Attach(ISubscriber observer);
        void Detach(ISubscriber observer);
        void CheckingConsole();
    }
}
