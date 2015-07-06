using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Patterns.Factory.TradeFeed
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var emOneFeedItems = new List<FeedItem>
            {
                new EmFeed
                {
                    CounterpartyId = 1234,
                    SourceAccountId = "test123",
                    Sedol = 23523,
                    AssetValue = 56560,
                    ValuationDate = new DateTime(),
                    CurrentPrice = 445,
                    PrincipalId = Convert.ToInt32(new Random().Next(150)),
                    StagingId = 569,
                    SourceTradeRef = "twtf"
                },
                new EmFeed
                {
                    CounterpartyId = 12345,
                    SourceAccountId = "test123",
                    Sedol = 6423,
                    AssetValue = 56586,
                    ValuationDate = new DateTime(),
                    CurrentPrice = 495,
                    PrincipalId = Convert.ToInt32(new Random().Next(140)),
                    StagingId = 506,
                    SourceTradeRef = "twert"
                }
            };

            var deltaOneFeedItems = new List<FeedItem>
            {
                new DeltaOne
                {
                    CounterpartyId = 123456,
                    SourceAccountId = "test123",
                    Isin = 785374,
                    MaturityDate = new DateTime(),
                    ValuationDate = new DateTime(),
                    CurrentPrice = 845,
                    PrincipalId = Convert.ToInt32(new Random().Next(130)),
                    StagingId = 856,
                    SourceTradeRef = "gse"
                },
                new DeltaOne
                {
                    CounterpartyId = 1234567,
                    SourceAccountId = "test123",
                    Isin = 2823,
                    MaturityDate = new DateTime(),
                    ValuationDate = new DateTime(),
                    CurrentPrice = 455,
                    PrincipalId = Convert.ToInt32(new Random().Next(120)),
                    StagingId = 576,
                    SourceTradeRef = "rew"
                },
                new EmFeed
                {
                    CounterpartyId = 12345,
                    SourceAccountId = "test123",
                    Sedol = 23273,
                    AssetValue = 56576,
                    ValuationDate = new DateTime(),
                    CurrentPrice = 75,
                    PrincipalId = Convert.ToInt32(new Random().Next(110)),
                    StagingId = 96,
                    SourceTradeRef = "twert"
                }
            };

            try
            {
				FeedManager emFactory = new FeedManagerFactory().CreateFeedManager("EmFeed");
				FeedManager deltaOneFactory = new FeedManagerFactory().CreateFeedManager("DeltaOne");
                emFactory.Process(emOneFeedItems);
                deltaOneFactory.Process(deltaOneFeedItems);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}