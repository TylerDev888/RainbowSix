namespace RainbowSix.Common.Database.Dtos
{
    public class NodeDto
    {
        public Guid Id { get; set; }
        public ItemDto Item { get; set; } = new ItemDto();
        public MarketDataDto MarketData { get; set; } = new MarketDataDto();
        public ViewerDto Viewer { get; set; } = new ViewerDto();
    }
}
