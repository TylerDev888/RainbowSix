namespace RainbowSix.Common.Database.Dtos
{
    public class MarketDataDto
    {
        public Guid Id { get; set; }
        public IEnumerable<StatDto> Stats { get; set; } = new List<StatDto>();
        public IEnumerable<LastSoldAtDto> LastSoldAt { get; set; } = new List<LastSoldAtDto>();
    }
}
