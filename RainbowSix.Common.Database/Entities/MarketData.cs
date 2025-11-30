namespace RainbowSix.Common.Database.Entities
{
    public class MarketData
    {
        public Guid Id { get; set; }

        public ICollection<Stat> Stats { get; set; } = new List<Stat>();
        public ICollection<LastSoldAt> LastSoldAt { get; set; } = new List<LastSoldAt>();
    }
}
