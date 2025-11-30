namespace RainbowSix.Common.Database.Entities
{
    public class PaymentOption
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public int Price { get; set; }
        public int TransactionFee { get; set; }
    }
}
