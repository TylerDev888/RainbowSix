using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class StoreItemViewerMetaModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("isOwned")]
        public bool? IsOwned { get; set; }

        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }
    }
}
