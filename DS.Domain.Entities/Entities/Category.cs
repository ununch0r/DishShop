using System;
using System.Collections.Generic;

#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class Category
    {
        public Category()
        {
            CategoriesCharacteristics = new HashSet<CategoriesCharacteristic>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CategoriesCharacteristic> CategoriesCharacteristics { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
