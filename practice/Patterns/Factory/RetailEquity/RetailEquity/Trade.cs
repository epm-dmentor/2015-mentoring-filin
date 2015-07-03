namespace Epam.NetMentoring.Patterns.Factory.RetailEquity
{
    internal class Trade
    {
        public Trade(string type, string subType, int amount)
        {
            Type = type;
            Amount = amount;
            SubType = subType;
        }

        public string Type { get; private set; }
        public int Amount { get; private set; }
        public string SubType { get; private set; }
    }
}