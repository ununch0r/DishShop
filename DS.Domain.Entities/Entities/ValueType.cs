using System.Collections.Generic;

namespace DS.Domain.Entities.Entities
{
    public class ValueType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public IEnumerable<Characteristic> Characteristics { get; set; }
    }
}
