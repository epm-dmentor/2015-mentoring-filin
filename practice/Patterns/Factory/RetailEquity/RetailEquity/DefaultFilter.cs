using System.Collections.Generic;

namespace Epam.NetMentoring.Patterns.Factory.RetailEquity
{
    internal class DefaultFilter : IFilter
    {
        public IEnumerable<Trade> Comply(IEnumerable<Trade> trades)
        {
            return trades;
        }
    }
}