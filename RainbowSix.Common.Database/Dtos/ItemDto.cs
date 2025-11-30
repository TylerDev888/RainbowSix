namespace RainbowSix.Common.Database.Dtos
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string AssetUrl { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Subtitle { get; set; }
        public string Type { get; set; }
        public int MaximumQuantity { get; set; }
        public IEnumerable<string> Tags { get; set; } = new List<string>();

        // Ownership fields
        public bool? IsOwned { get; set; }
        public int? Quantity { get; set; }
    }
}
