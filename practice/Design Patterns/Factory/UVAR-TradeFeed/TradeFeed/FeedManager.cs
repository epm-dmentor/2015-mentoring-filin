using System.Collections.Generic;

namespace Epam.NetMentoring.Patterns.Factory.TradeFeed
{
    public abstract class FeedManager
    {
        public abstract IFeedProcessor FeedProcessor { get; }

        public void Process(IEnumerable<FeedItem> feedItems)
        {
            foreach (FeedItem item in feedItems)
            {
                FeedProcessor.Validate(item);
                FeedProcessor.Meet(item);
                FeedProcessor.Save(item);
            }
        }
    }
}