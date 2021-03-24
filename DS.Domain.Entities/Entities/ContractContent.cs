namespace DS.Domain.Entities.Entities
{
    public class ContractContent
    {
        public int ContractId { get; set; }
        public int ProductId { get; set; }
        public decimal PricePerUnit { get; set; }

        public Contract Contract { get; set; }
        public Producer Producer { get; set; }
    }
}
