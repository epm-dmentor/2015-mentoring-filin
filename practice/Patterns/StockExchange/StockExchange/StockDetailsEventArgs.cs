using System;

namespace Epam.Mentoring.Patterns.Observer.StockExchange
{
    class StockDetailsEventArgs : EventArgs
    {
        public double StockPrice { get; set; }
    }
}
