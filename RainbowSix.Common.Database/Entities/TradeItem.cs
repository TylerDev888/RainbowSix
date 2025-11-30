namespace RainbowSix.Common.Database.Entities
{
    public class TradeItem
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
    }
}
