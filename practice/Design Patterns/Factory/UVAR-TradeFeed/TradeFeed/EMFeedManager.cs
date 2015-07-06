namespace Epam.NetMentoring.Patterns.Factory.TradeFeed
{
    public class EmFeedManager : FeedManager
    {
        public override IFeedProcessor FeedProcessor
        {
            get { return new EmFeedProcessor(); }
        }
    }
}