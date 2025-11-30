namespace RainbowSix.Common.Database.Dtos
{
    public class UserGamePurchaseLimitationsDto
    {
        public int ResolvedTransactionCount { get; set; }
        public int ResolvedTransactionPeriodInMinutes { get; set; }
        public int ActiveTransactionCount { get; set; }
    }
}
