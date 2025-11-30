using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class UserGameMetaModel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("marketableItems")]
        public MarketableItemsModel? MarketableItems { get; set; }
    }
}
