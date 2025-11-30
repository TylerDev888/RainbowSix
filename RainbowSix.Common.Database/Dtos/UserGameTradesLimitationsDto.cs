namespace RainbowSix.Common.Database.Dtos
{
    public class UserGameTradesLimitationsDto
    {
        public Guid Id { get; set; }
        public UserGamePurchaseLimitationsDto Buy { get; set; }
        public UserGameSaleLimitationsDto Sell { get; set; }
    }
}
