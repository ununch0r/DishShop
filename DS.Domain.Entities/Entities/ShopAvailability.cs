namespace DS.Domain.Entities.Entities
{
    public class ShopAvailability
    {
        public int ShopId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }

        public Shop Shop { get; set; }
        public Product Product { get; set; }
    }
}
