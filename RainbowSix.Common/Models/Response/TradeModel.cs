using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class TradeModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("tradeId")]
        public string TradeId { get; set; } = string.Empty;

        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;

        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("expiresAt")]
        public DateTime ExpiresAt { get; set; }

        [JsonPropertyName("lastModifiedAt")]
        public DateTime LastModifiedAt { get; set; }

        [JsonPropertyName("failures")]
        public List<string>? Failures { get; set; }

        [JsonPropertyName("tradeItems")]
        public List<TradeItemModel>? TradeItems { get; set; }

        [JsonPropertyName("payment")]
        public PaymentModel? Payment { get; set; }

        [JsonPropertyName("paymentOptions")]
        public List<PaymentOptionModel>? PaymentOptions { get; set; }

        [JsonPropertyName("paymentProposal")]
        public PaymentProposalmodel? PaymentProposal { get; set; }

        [JsonPropertyName("viewer")]
        public TradeViewerModel? Viewer { get; set; }
    }
}
