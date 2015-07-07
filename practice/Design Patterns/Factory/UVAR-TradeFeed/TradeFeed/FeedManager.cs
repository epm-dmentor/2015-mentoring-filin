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
                //BK: Here I believe you have to save validation errors somehow acording to requirments. Your method returns data, but you omit them
                FeedProcessor.Validate(item);
                FeedProcessor.Meet(item);
                FeedProcessor.Save(item);
            }
        }
    }
}