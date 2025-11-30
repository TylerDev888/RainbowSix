using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class UserGameTradesLimitationsModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("buy")]
        public BuyLimitationsModel? Buy { get; set; }

        [JsonPropertyName("sell")]
        public SellLimitationsModel? Sell { get; set; }
    }
}
