namespace RainbowSix.Common.Database.Dtos
{
    public class LastSoldAtDto
    {
        public Guid Id { get; set; }
        public string PaymentItemId { get; set; }
        public int Price { get; set; }
        public DateTime PerformedAt { get; set; }
    }
}
