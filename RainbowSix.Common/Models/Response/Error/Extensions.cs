using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response.Error
{
    public class Extensions
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }
    }
}
