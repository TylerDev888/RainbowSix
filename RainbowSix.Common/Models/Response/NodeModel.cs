using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class NodeModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("item")]
        public StoreItemModel? Item { get; set; }

        [JsonPropertyName("marketData")]
        public MarketDataModel? MarketData { get; set; }

        [JsonPropertyName("viewer")]
        public ViewerMetaModel? Viewer { get; set; }
    }
}
