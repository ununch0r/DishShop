using System;
using System.Collections.Generic;

#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class ShopsAvailability
    {
        public int ShopId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }

        public virtual Product Product { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
