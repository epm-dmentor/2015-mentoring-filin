using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Patterns.Factory.TradeFeed
{
    public class Accounts
    {
        private static readonly Dictionary<int, string> EmIds = new Dictionary<int, string>();
        private static readonly Dictionary<int, decimal> DeltaOneIds = new Dictionary<int, decimal>();

        public static void CheckAccount(FeedItem feedItem)
        {
            if (feedItem is EmFeed)
            {
                if (EmIds.ContainsKey(feedItem.SourceAccountId.GetHashCode())) return;
                EmIds.Add(feedItem.SourceAccountId.GetHashCode(), feedItem.SourceAccountId);
                Console.WriteLine(" Account {0} has been created for EM Feed {1}", feedItem.SourceAccountId, feedItem.PrincipalId);
            }
            if (feedItem is DeltaOne)
            {
                decimal checkAccount = feedItem.CounterpartyId + feedItem.PrincipalId;
                if (DeltaOneIds.ContainsKey(checkAccount.GetHashCode())) return;
                DeltaOneIds.Add(checkAccount.GetHashCode(), checkAccount);
                Console.WriteLine(" Account {0} has been created for DeltaOne Feed {1}", checkAccount, feedItem.PrincipalId);
            }
        }
    }
}