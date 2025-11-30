using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Request
{
    public class QueryMarketPlaceItemsVariables
    {
        [JsonPropertyName("withOwnership")]
        public bool WithOwnership { get; set; } = false;

        [JsonPropertyName("spaceId")]
        public string SpaceId { get; set; } = string.Empty;

        [JsonPropertyName("limit")]
        public int Limit { get; set; } = 40;

        [JsonPropertyName("offset")]
        public int Offset { get; set; } = 0;

        [JsonPropertyName("filterBy")]
        public object? FilterBy { get; set; } = new { };

        [JsonPropertyName("sortBy")]
        public SortBy? SortBy { get; set; }
    }
}
