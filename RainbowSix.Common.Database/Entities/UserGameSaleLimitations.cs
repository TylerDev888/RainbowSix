namespace RainbowSix.Common.Database.Entities
{
    public class UserGameSaleLimitations
    {
        public Guid Id { get; set; }
        public int ResolvedTransactionCount { get; set; }
        public int ResolvedTransactionPeriodInMinutes { get; set; }
        public int ActiveTransactionCount { get; set; }

        public ICollection<UserGameResaleLock> ResaleLocks { get; set; } = new List<UserGameResaleLock>();
    }
}
