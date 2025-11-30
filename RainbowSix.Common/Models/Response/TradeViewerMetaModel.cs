using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class TradeViewerMetaModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("tradesLimitations")]
        public UserGameTradesLimitationsModel? TradesLimitations { get; set; }
    }
}
