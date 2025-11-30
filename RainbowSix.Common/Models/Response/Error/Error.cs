using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response.Error
{
    public class Error
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("locations")]
        public List<Location>? Locations { get; set; }

        [JsonPropertyName("path")]
        public List<string>? Path { get; set; }

        [JsonPropertyName("extensions")]
        public Extensions? Extensions { get; set; }
    }
}
