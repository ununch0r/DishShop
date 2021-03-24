using System.Collections.Generic;

namespace DS.Domain.Entities.Entities
{
    public class Characteristic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ValueTypeId { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ProductCharacteristic> ProductCharacteristics { get; set; }
        public ValueType ValueType { get; set; }
    }
}
