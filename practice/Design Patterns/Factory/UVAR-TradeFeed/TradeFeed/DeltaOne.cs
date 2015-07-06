using System;

namespace Epam.NetMentoring.Patterns.Factory.TradeFeed
{
    public class DeltaOne : FeedItem
    {
        public decimal Isin { get; set; }
        public DateTime MaturityDate { get; set; }
    }
}