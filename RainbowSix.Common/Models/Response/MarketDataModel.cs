using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class MarketDataModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("sellStats")]
        public List<OrderStatsModel>? SellStats { get; set; }

        [JsonPropertyName("buyStats")]
        public List<OrderStatsModel>? BuyStats { get; set; }

        [JsonPropertyName("lastSoldAt")]
        public List<LastOrderStatsModel>? LastSoldAt { get; set; }
    }
}
