using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class MarketableItemsModel
    {
        [JsonPropertyName("nodes")]
        public List<NodeModel>? Nodes { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }
    }
}
