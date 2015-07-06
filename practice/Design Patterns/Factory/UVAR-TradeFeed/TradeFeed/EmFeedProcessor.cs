using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Patterns.Factory.TradeFeed
{
    public class EmFeedProcessor : IFeedProcessor
    {
        public IEnumerable<Validation> Validate(FeedItem feeditem)
        {
            var validation = new List<Validation>();

            if (string.IsNullOrEmpty(feeditem.SourceAccountId))
            {
                validation.Add(new Validation {ValidationMessage = "CounterpartyId must not be 0"});
            }

            return validation;
        }

        public void Meet(FeedItem feedItem)
        {
            var emFeed = feedItem as EmFeed;
            if (emFeed == null)
                throw new Exception("Not Supported FeedItem for EMFeed");
            Accounts.CheckAccount(feedItem);
        }

        public void Save(FeedItem feed)
        {
            Console.WriteLine("EM Feed {0} has been saved", feed.PrincipalId);
        }
    }
}