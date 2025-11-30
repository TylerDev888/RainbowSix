using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class ResaleLockModel
    {
        [JsonPropertyName("itemId")]
        public string ItemId { get; set; } = string.Empty;

        [JsonPropertyName("expiresAt")]
        public DateTime ExpiresAt { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
