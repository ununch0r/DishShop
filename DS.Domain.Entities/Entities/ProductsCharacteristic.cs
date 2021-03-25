#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class ProductsCharacteristic
    {
        public int ProductId { get; set; }
        public int CharacteristicId { get; set; }
        public decimal? Value { get; set; }

        public virtual Characteristic Characteristic { get; set; }
        public virtual Product Product { get; set; }
    }
}
