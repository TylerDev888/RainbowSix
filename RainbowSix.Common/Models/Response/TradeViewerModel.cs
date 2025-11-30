using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class TradeViewerModel
    {
        [JsonPropertyName("meta")]
        public TradeViewerMetaModel? Meta { get; set; }
    }
}
