namespace RainbowSix.Common.Database.Entities
{

    public class UserGameResaleLock
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public DateTime ExpiresAt { get; set; }
        public int Quantity { get; set; }

        public Guid SaleLimitationsId { get; set; }
        public UserGameSaleLimitations SaleLimitations { get; set; }
    }
}
