using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Patterns.Factory.TradeFeed
{
    public class DeltaOneFeedProcessor : IFeedProcessor
    {
        public IEnumerable<Validation> Validate(FeedItem feeditem)
        {
            var validation = new List<Validation>();

            if (feeditem.CounterpartyId == 0)
            {
                validation.Add(new Validation {ValidationMessage = "CounterpartyId must not be 0"});
            }
            if (feeditem.PrincipalId == 0)
            {
                validation.Add(new Validation {ValidationMessage = "PrincipalId must not be 0"});
            }

            return validation;
        }
        //BK: Throwing an exception? By doing so you will break all the other feeds. You need some more flexible logic here
        public void Meet(FeedItem feedItem)
        {
            var deltaOneFeed = feedItem as DeltaOne;
            if (deltaOneFeed == null)
                throw new Exception("Not Supported FeedItem for DeltaOne.");
            Accounts.CheckAccount(feedItem);
        }

        public void Save(FeedItem feed)
        {
            Console.WriteLine("DeltaOne Feed {0} has been saved", feed.PrincipalId);
        }
    }
}