using System;
using System.Collections.Generic;

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
        public string Description { get; set; }
        public int? ValueTypeId { get; set; }

        public virtual ValueType ValueType { get; set; }
        public virtual ICollection<CategoriesCharacteristic> CategoriesCharacteristics { get; set; }
        public virtual ICollection<ProductsCharacteristic> ProductsCharacteristics { get; set; }
    }
}
