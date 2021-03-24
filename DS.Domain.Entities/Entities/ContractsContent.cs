using System;
using System.Collections.Generic;

#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class ContractsContent
    {
        public int ContractId { get; set; }
        public int ProductId { get; set; }
        public decimal PricePerUnit { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual Product Product { get; set; }
    }
}
