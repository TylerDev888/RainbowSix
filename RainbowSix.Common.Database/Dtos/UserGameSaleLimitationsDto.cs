namespace RainbowSix.Common.Database.Dtos
{
    public class UserGameSaleLimitationsDto
    {
        public int ResolvedTransactionCount { get; set; }
        public int ResolvedTransactionPeriodInMinutes { get; set; }
        public int ActiveTransactionCount { get; set; }
        public IEnumerable<UserGameResaleLockDto> ResaleLocks { get; set; } = new List<UserGameResaleLockDto>();
    }
}
