namespace RainbowSix.Common.Database.Dtos
{
    public class ViewerMetaDto
    {
        public Guid Id { get; set; }
        public TradeDto? ActiveTrade { get; set; }
    }
}
