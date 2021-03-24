namespace DS.Domain.Entities.Entities
{
    public class SupplyContent
    {
        public int SupplyId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }

        public Supply Supply { get; set; }
        public Product Product { get; set; }
    }
}
