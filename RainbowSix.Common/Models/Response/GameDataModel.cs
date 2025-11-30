using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class GameDataModel
    {
        [JsonPropertyName("game")]
        public GameModel? Game { get; set; }
    }
}
