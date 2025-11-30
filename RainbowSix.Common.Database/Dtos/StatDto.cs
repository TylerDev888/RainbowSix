namespace RainbowSix.Common.Database.Dtos
{
    public class StatDto
    {
        public Guid Id { get; set; }
        public string PaymentItemId { get; set; }
        public int LowestPrice { get; set; }
        public int HighestPrice { get; set; }
        public int ActiveCount { get; set; }
        public string StatType { get; set; } // "Sell" or "Buy"
    }
}
