using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RainbowSix.Common.Models.Response
{
    public class GameModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("viewer")]
        public ViewerModel? Viewer { get; set; }
        [JsonPropertyName("marketableItems")]
        public MarketableItemsModel? MarketableItems { get; set; }
    }
}
