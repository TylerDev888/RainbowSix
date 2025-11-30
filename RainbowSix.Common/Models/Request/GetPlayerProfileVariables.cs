using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Request
{
    public class GetPlayerProfileVariables
    {
        [JsonPropertyName("spaceId")]
        public string SpaceId { get; set; } = string.Empty;

        [JsonPropertyName("privilegeIds")]
        public string[] PrivilegeIds { get; set; } = Array.Empty<string>();
    }
}
