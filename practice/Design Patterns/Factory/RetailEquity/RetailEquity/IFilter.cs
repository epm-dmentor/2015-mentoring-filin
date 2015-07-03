using System.Collections.Generic;

namespace Epam.NetMentoring.Patterns.Factory.RetailEquity
{
    internal interface IFilter
    {
        IEnumerable<Trade> Comply(IEnumerable<Trade> trades);
    }
}