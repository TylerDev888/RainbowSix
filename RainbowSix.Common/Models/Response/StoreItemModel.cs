using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class StoreItemModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("assetUrl")]
        public string? AssetUrl { get; set; }

        [JsonPropertyName("itemId")]
        public string? ItemId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("subtitle")]
        public string? Subtitle { get; set; }

        [JsonPropertyName("tags")]
        public List<string>? Tags { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("maximumQuantity")]
        public int? MaximumQuantity { get; set; }

        [JsonPropertyName("viewer")]
        public StoreItemViewerModel? Viewer { get; set; }
    }
}
