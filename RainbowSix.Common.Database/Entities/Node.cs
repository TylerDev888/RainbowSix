namespace RainbowSix.Common.Database.Entities
{
    public class Node
    {
        public Guid Id { get; set; }

        public Guid ItemId { get; set; }
        public Item Item { get; set; }

        public Guid MarketDataId { get; set; }
        public MarketData MarketData { get; set; }

        public Guid ViewerId { get; set; }
        public Viewer Viewer { get; set; }
    }
}
