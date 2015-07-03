namespace Epam.NetMentoring.Patterns.Factory.RetailEquity
{
    internal interface IFilterFactory
    {
        IFilter Filter(string filtername);
    }
}