using System.Collections.Generic;

#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class ValueType
    {
        public ValueType()
        {
            Characteristics = new HashSet<Characteristic>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Characteristic> Characteristics { get; set; }
    }
}
