namespace Epam.NetMentoring.Patterns.Factory.TradeFeed
{
    public class DeltaOneFeedManager : FeedManager
    {
        public override IFeedProcessor FeedProcessor
        {
            get { return new DeltaOneFeedProcessor(); }
        }
    }
}