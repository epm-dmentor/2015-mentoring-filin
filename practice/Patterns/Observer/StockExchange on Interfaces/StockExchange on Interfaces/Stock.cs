namespace Epam.NetMentoring.Patterns.Observer.StockExchange_on_Interfaces
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
