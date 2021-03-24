using System.Collections.Generic;

namespace DS.Domain.Entities.Entities
{
    public class SupplyStatus
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public IEnumerable<Supply> Supplies { get; set; }
    }
}
