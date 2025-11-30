namespace RainbowSix.Common.Database.Dtos
{

    public class UserGameResaleLockDto
    {
        public string ItemId { get; set; }
        public DateTime ExpiresAt { get; set; }
        public int Quantity { get; set; }
    }
}
