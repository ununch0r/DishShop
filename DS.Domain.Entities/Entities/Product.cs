using System.Collections.Generic;

namespace DS.Domain.Entities.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ScanCode { get; set; }
        public int ProducerId { get; set; }
        public int CategoryId { get; set; }

        public Producer Producer { get; set; }
        public Category Category { get; set; }
        public IEnumerable<ProductCharacteristic> ProductCharacteristics { get; set; }
        public IEnumerable<ShopAvailability> ShopAvailabilities { get; set; }
        public IEnumerable<SupplyContent> SupplyContents { get; set; }
    }
}
