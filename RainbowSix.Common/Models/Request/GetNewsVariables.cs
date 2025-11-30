using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Request
{
    public class GetNewsVariables
    {
        [JsonPropertyName("spaceId")]
        public string SpaceId { get; set; } = string.Empty;

        [JsonPropertyName("placements")]
        public string[] Placements { get; set; } = Array.Empty<string>();

        [JsonPropertyName("newsTypes")]
        public string[] NewsTypes { get; set; } = Array.Empty<string>();
    }
}
