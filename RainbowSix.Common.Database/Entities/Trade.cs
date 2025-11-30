namespace RainbowSix.Common.Database.Entities
{
    public class Trade
    {
        public Guid Id { get; set; }
        public string TradeId { get; set; }
        public string State { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime LastModifiedAt { get; set; }

        public ICollection<TradeItem> TradeItems { get; set; } = new List<TradeItem>();
        public ICollection<PaymentOption> PaymentOptions { get; set; } = new List<PaymentOption>();

        public Guid? TradesLimitationsId { get; set; }
        public UserGameTradesLimitations? Viewer { get; set; }
    }
}
