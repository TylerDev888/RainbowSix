using System.Diagnostics;
using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class ViewerMetaModel
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }
        [JsonPropertyName("activeTradeId")]
        public Guid? ActiveTradeId { get; set; }
        [JsonPropertyName("trade")]
        public TradeModel? ActiveTrade { get; set; }
    }
}
