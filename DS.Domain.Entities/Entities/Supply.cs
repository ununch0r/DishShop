using System;
using System.Collections.Generic;

#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class Supply
    {
        public Supply()
        {
            SuppliesContents = new HashSet<SuppliesContent>();
        }

        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateReceived { get; set; }
        public int ContractId { get; set; }
        public int CreatorId { get; set; }
        public int ShopId { get; set; }
        public int StatusId { get; set; }
        public DateTime? DateCanceled { get; set; }
        public int? CancellerId { get; set; }
        public int? ReceiverId { get; set; }

        public virtual Employee Canceller { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual Employee Creator { get; set; }
        public virtual Employee Receiver { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual SupplyStatus Status { get; set; }
        public virtual ICollection<SuppliesContent> SuppliesContents { get; set; }
    }
}
