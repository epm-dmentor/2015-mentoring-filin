namespace Epam.NetMentoring.Patterns.Observer
{
    interface ISubscriber
    {
        void Update(string eventDetails);
    }
}
