using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class SellLimitationsModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("resolvedTransactionCount")]
        public int ResolvedTransactionCount { get; set; }

        [JsonPropertyName("resolvedTransactionPeriodInMinutes")]
        public int ResolvedTransactionPeriodInMinutes { get; set; }

        [JsonPropertyName("activeTransactionCount")]
        public int ActiveTransactionCount { get; set; }

        [JsonPropertyName("resaleLocks")]
        public List<ResaleLockModel>? ResaleLocks { get; set; }
    }
}
