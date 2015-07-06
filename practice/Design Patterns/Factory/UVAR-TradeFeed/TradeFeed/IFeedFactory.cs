namespace Epam.NetMentoring.Patterns.Factory.TradeFeed
{
    public interface IFeedManagerFactory
    {
        FeedManager CreateFeedManager(string feedType);
    }
}