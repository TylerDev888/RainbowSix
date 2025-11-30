using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class ViewerModel
    {
        [JsonPropertyName("meta")]
        public UserGameMetaModel? Meta { get; set; }
    }
}
