using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Request
{
    public class GetTradesLimitationsVariables
    {
        [JsonPropertyName("spaceId")]
        public string SpaceId { get; set; } = string.Empty;
    }
}
