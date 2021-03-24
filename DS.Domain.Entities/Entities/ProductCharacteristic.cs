namespace DS.Domain.Entities.Entities
{
    public class ProductCharacteristic
    {
        public int ProductId { get; set; }
        public int CharacteristicId { get; set; }
        public int Value  { get; set; }

        public Product Product { get; set; }
        public Characteristic Characteristic { get; set; }
    }
}
