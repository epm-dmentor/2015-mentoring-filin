﻿using System;

namespace Epam.NetMentoring.Patterns.Observer.StockExchangeOnDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            //BK: The main idea of writing stovk exchnage on delegates is that there is no attach/detach actions. 
            //According to a task market should have a delegate, to which all your Investors will subscribe. 
            //THe benefit of using delegates events is that subscribers shouldn't have single common interface.
            //BK: The same story is about Events. PLease reimplement both and avoid using interfaces here for subscribers.
            //AF: I removed interface and left delegate only 

            Stock epam = new Stock("epam", 14.00, 7.00);
            StockMarketing market = new StockMarketing(epam);
            Investor alex = new Investor("Alex", 12.00, epam);
            Investor mark = new Investor("Mark", 11.00, epam);

            market.PriceChangedEvent += alex.StockPriceChanged;
            market.PriceChangedEvent += mark.StockPriceChanged;

            //market.Attach(alex);
            //market.Attach(mark);

            market.OpeningTenders();

            Console.ReadKey();
        }
    }
}
