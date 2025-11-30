namespace RainbowSix.Common.Database.Entities
{
    public class UserGamePurchaseLimitations
    {
        public Guid Id { get; set; }
        public int ResolvedTransactionCount { get; set; }
        public int ResolvedTransactionPeriodInMinutes { get; set; }
        public int ActiveTransactionCount { get; set; }
    }
}
