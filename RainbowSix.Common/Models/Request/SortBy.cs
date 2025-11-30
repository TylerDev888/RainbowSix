using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Request
{
    public class SortBy
    {
        [JsonPropertyName("field")]
        public string Field { get; set; } = string.Empty;

        [JsonPropertyName("orderType")]
        public string OrderType { get; set; } = string.Empty;

        [JsonPropertyName("direction")]
        public string Direction { get; set; } = string.Empty;

        [JsonPropertyName("paymentItemId")]
        public string PaymentItemId { get; set; } = string.Empty;
    }
}
