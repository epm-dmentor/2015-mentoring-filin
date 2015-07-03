using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Patterns.Factory.RetailEquity
{
    internal class BarclaysFilter : IFilter
    {
        private const string Type = "Option";
        private const string SubType = "NyOption";
        private const int Amount = 50;

        public IEnumerable<Trade> Comply(IEnumerable<Trade> trades)
        {
            return trades.Where(t => t.Type.Equals(Type) &&
                                     t.SubType.Equals(SubType) &&
                                     t.Amount > Amount);
        }
    }
}