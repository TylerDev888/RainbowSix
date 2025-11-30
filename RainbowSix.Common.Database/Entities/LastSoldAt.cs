namespace RainbowSix.Common.Database.Entities
{
    public class LastSoldAt
    {
        public Guid Id { get; set; }
        public string PaymentItemId { get; set; }
        public int Price { get; set; }
        public DateTime PerformedAt { get; set; }

        public Guid MarketDataId { get; set; }
        public MarketData MarketData { get; set; }
    }
}
