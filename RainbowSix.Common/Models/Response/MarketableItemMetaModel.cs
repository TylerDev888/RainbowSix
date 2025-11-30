using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class MarketableItemMetaModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("activeTrade")]
        public TradeModel? ActiveTrade { get; set; }
    }
}
