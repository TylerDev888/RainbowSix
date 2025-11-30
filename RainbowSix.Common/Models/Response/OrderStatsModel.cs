using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class OrderStatsModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("paymentItemId")]
        public string? PaymentItemId { get; set; }

        [JsonPropertyName("lowestPrice")]
        public int LowestPrice { get; set; }

        [JsonPropertyName("highestPrice")]
        public int HighestPrice { get; set; }

        [JsonPropertyName("activeCount")]
        public int ActiveCount { get; set; }
    }
}
