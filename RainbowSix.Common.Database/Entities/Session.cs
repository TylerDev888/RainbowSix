using RainbowSix.Common.Interfaces;
using System.Text.Json.Serialization;

namespace RainbowSix.Common.Database.Entities
{
    public class Session : IUbisoftSession
    {
        public string? Username { get; set; }
        public string? MaskedPhone { get; set; }
        public string? PlatformType { get; set; }
        public string? Ticket { get; set; }
        public string? TwoFactorAuthenticationTicket { get; set; }
        public string? ProfileId { get; set; }
        public string? UserId { get; set; }
        public string NameOnPlatform { get; set; } = string.Empty;
        public string? Environment { get; set; }
        public DateTime? Expiration { get; set; }
        public string? SpaceId { get; set; }
        public string? ClientIp { get; set; }
        public string? ClientIpCountry { get; set; }
        public string? ServerTime { get; set; }
        public string? SessionId { get; set; }
        public string? RememberMeTicket { get; set; }
        public string[]? CodeGenerationPreference { get; set; }
        public string? CodeCommunicationPreference { get; set; }
    }
}
