using System.Text.Json.Serialization;

namespace RainbowSix.Common.Models.Response
{
    public class PaymentOptionModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("item")]
        public StoreItemModel? Item { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("transactionFee")]
        public int TransactionFee { get; set; }
    }
}
