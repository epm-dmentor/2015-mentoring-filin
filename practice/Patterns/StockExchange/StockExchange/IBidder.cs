namespace Epam.Mentoring.Patterns.Observer.StockExchange
{
    internal interface IBidder
    {
        void StockPriceChanged(object sender, StockDetailsEventArgs e);
    }
}
