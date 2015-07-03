using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Patterns.Factory.RetailEquity
{
    internal class ConnacordFilter : IFilter
    {
        private const string Type = "Future";
        private const int MinAmount = 10;
        private const int MaxAmount = 40;

        public IEnumerable<Trade> Comply(IEnumerable<Trade> trades)
        {
            return trades.Where(t => t.Type.Equals(Type) &&
                                     t.Amount > MinAmount &&
                                     t.Amount < MaxAmount);
        }
    }
}