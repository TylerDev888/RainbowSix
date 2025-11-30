namespace RainbowSix.Common.Database.Entities
{
    public class ViewerMeta
    {
        public Guid Id { get; set; }
        public Guid? ActiveTradeId { get; set; }
        public Trade? ActiveTrade { get; set; }
    }
}
