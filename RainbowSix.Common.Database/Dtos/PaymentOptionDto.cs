namespace RainbowSix.Common.Database.Dtos
{
    public class PaymentOptionDto
    {
        public Guid Id { get; set; }
        public ItemDto Item { get; set; }
        public int Price { get; set; }
        public int TransactionFee { get; set; }
    }
}
