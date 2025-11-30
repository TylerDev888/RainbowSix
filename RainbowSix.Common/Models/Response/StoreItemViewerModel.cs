using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class StoreItemViewerModel
    {
        [JsonPropertyName("meta")]
        public StoreItemViewerMetaModel? Meta { get; set; }
    }
}
