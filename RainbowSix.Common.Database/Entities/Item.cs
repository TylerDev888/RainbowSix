namespace RainbowSix.Common.Database.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string AssetUrl { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Subtitle { get; set; }
        public string Type { get; set; }
        public int MaximumQuantity { get; set; }

        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
