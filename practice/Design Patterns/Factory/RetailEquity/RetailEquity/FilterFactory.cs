namespace Epam.NetMentoring.Patterns.Factory.RetailEquity
{
    internal class FilterFactory : IFilterFactory
    {
        public IFilter Filter(string filtername)
        {
            switch (filtername)
            {
                case "Barclays":
                    return new BarclaysFilter();
                case "Bofa":
                    return new BofaFilter();
                case "Connacord":
                    return new ConnacordFilter();
                default:
                    return new DefaultFilter();
            }
        }
    }
}