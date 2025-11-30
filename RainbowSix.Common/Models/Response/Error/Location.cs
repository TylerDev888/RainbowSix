using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response.Error
{
    public class Location
    {
        [JsonPropertyName("line")]
        public int Line { get; set; }

        [JsonPropertyName("column")]
        public int Column { get; set; }
    }
}
