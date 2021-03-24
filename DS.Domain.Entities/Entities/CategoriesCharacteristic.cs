#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class CategoriesCharacteristic
    {
        public int CategoryId { get; set; }
        public int CharacteristicId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Characteristic Characteristic { get; set; }
    }
}
