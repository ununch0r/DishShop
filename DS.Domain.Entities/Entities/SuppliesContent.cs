using System;
using System.Collections.Generic;

#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class SuppliesContent
    {
        public int SupplyId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }

        public virtual Product Product { get; set; }
        public virtual Supply Supply { get; set; }
    }
}
