using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class TradeItemModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("item")]
        public StoreItemModel? Item { get; set; }
    }
}
