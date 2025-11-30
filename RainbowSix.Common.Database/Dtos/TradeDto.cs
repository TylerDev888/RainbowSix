namespace RainbowSix.Common.Database.Dtos
{
    public class TradeDto
    {
        public Guid Id { get; set; }
        public string TradeId { get; set; }
        public string State { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public IEnumerable<TradeItemDto> TradeItems { get; set; } = new List<TradeItemDto>();
        public IEnumerable<PaymentOptionDto> PaymentOptions { get; set; } = new List<PaymentOptionDto>();
        public List<string> Failures { get; set; } = new List<string>();
    }
}
