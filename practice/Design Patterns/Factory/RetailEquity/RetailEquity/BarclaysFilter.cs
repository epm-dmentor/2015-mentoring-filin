using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Patterns.Factory.RetailEquity
{
    internal class BarclaysFilter : IFilter
    {
        //BK: I would recomend you to write conts all in upper case like TYPE, SUB_TYPE etc. Thus you always see where your code uses cont
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