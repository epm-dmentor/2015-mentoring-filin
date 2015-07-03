using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Patterns.Factory.RetailEquity
{
    internal class BofaFilter : IFilter
    {
        private const int MaxAmount = 70;

        public IEnumerable<Trade> Comply(IEnumerable<Trade> trades)
        {
            return trades.Where(t => t.Amount > MaxAmount);
        }
    }
}