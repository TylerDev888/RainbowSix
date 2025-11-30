namespace RainbowSix.Common.Database.Entities
{
    public class UserGameTradesLimitations
    {
        public Guid Id { get; set; }
        public UserGamePurchaseLimitations Buy { get; set; }
        public UserGameSaleLimitations Sell { get; set; }
    }
}
