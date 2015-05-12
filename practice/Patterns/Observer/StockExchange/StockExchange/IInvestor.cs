namespace Epam.Mentoring.Patterns.Observer.StockExchange
{
    interface IInvestor
    {
        void StockPriceChanged(object sender, StockDetailsEventArgs e);
    }
}
