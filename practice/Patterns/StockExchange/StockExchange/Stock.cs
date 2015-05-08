namespace Epam.Mentoring.Patterns.Observer.StockExchange
{
    class Stock
    {
        public string Name { get; set; }
        public double StartPrice { get; set; }
        public double ClosingPrice { get; set; }

        public Stock(string name, double startPrice, double closingPrice)
        {
            Name = name;
            StartPrice = startPrice;
            ClosingPrice = closingPrice;
        }
    }
}
