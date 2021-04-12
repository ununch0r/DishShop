using System.Collections.Generic;

#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class SupplyStatus
    {
        public SupplyStatus()
        {
            Supplies = new HashSet<Supply>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
