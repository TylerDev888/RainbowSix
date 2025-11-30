using RainbowSix.Common.Interfaces;
using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class UbisoftAuthResponseModel : IUbisoftSession
    {
        [JsonPropertyName("userName")]
        public string? Username { get; set; }
        [JsonPropertyName("maskedPhone")]
        public string? MaskedPhone { get; set; }

        [JsonPropertyName("platformType")]
        public string? PlatformType { get; set; }

        [JsonPropertyName("ticket")]
        public string? Ticket { get; set; }

        [JsonPropertyName("twoFactorAuthenticationTicket")]
        public string? TwoFactorAuthenticationTicket { get; set; }

        [JsonPropertyName("profileId")]
        public string? ProfileId { get; set; }

        [JsonPropertyName("userId")]
        public string? UserId { get; set; }

        [JsonPropertyName("nameOnPlatform")]
        public string NameOnPlatform { get; set; } = string.Empty;

        [JsonPropertyName("environment")]
        public string? Environment { get; set; }

        [JsonPropertyName("expiration")]
        public DateTime? Expiration { get; set; }

        [JsonPropertyName("spaceId")]
        public string? SpaceId { get; set; }

        [JsonPropertyName("clientIp")]
        public string? ClientIp { get; set; }

        [JsonPropertyName("clientIpCountry")]
        public string? ClientIpCountry { get; set; }

        [JsonPropertyName("serverTime")]
        public string? ServerTime { get; set; }

        [JsonPropertyName("sessionId")]
        public string? SessionId { get; set; }

        [JsonPropertyName("rememberMeTicket")]
        public string? RememberMeTicket { get; set; }

        [JsonPropertyName("codeGenerationPreference")]
        public string[]? CodeGenerationPreference { get; set; } 

        [JsonPropertyName("codeCommunicationPreference")]
        public string? CodeCommunicationPreference { get; set; }
    }
}
