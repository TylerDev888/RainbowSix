using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class LastOrderStatsModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("paymentItemId")]
        public string? PaymentItemId { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("performedAt")]
        public DateTime PerformedAt { get; set; }
    }
}
