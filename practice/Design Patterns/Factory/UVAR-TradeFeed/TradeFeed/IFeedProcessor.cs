using System.Collections.Generic;

namespace Epam.NetMentoring.Patterns.Factory.TradeFeed
{
    public interface IFeedProcessor
    {
        IEnumerable<Validation> Validate(FeedItem feeditem);
        void Meet(FeedItem feedItem);
        void Save(FeedItem feed);
    }
}