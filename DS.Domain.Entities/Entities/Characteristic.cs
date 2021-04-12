using System.Collections.Generic;
using ValueType = DS.Domain.Entities.Entities.ValueType;

#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class Characteristic
    {
        public Characteristic()
        {
            CategoriesCharacteristics = new HashSet<CategoriesCharacteristic>();
            ProductsCharacteristics = new HashSet<ProductsCharacteristic>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ValueTypeId { get; set; }

        public virtual ValueType ValueType { get; set; }
        public virtual ICollection<CategoriesCharacteristic> CategoriesCharacteristics { get; set; }
        public virtual ICollection<ProductsCharacteristic> ProductsCharacteristics { get; set; }
    }
}
