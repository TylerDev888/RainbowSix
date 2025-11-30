using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Request
{
    public class GetBalanceVariables
    {
        [JsonPropertyName("spaceId")]
        public string SpaceId { get; set; } = string.Empty;

        [JsonPropertyName("itemId")]
        public string ItemId { get; set; } = string.Empty;
    }
}
