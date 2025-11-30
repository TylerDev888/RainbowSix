namespace RainbowSix.Common.Database.Entities
{
    public class Stat
    {
        public Guid Id { get; set; }
        public string PaymentItemId { get; set; }
        public int LowestPrice { get; set; }
        public int HighestPrice { get; set; }
        public int ActiveCount { get; set; }

        public StatType StatType { get; set; }

        public Guid MarketDataId { get; set; }
        public MarketData MarketData { get; set; }
    }
}
