using System;
using System.Collections.Generic;

#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class Product
    {
        public Product()
        {
            ContractsContents = new HashSet<ContractsContent>();
            ProductsCharacteristics = new HashSet<ProductsCharacteristic>();
            ShopsAvailabilities = new HashSet<ShopsAvailability>();
            SuppliesContents = new HashSet<SuppliesContent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ScanCode { get; set; }
        public int ProducerId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual ICollection<ContractsContent> ContractsContents { get; set; }
        public virtual ICollection<ProductsCharacteristic> ProductsCharacteristics { get; set; }
        public virtual ICollection<ShopsAvailability> ShopsAvailabilities { get; set; }
        public virtual ICollection<SuppliesContent> SuppliesContents { get; set; }
    }
}
