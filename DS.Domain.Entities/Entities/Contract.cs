using System;
using System.Collections.Generic;

#nullable disable

namespace DS.Domain.Entities.Entities
{
    public partial class Contract
    {
        public Contract()
        {
            ContractsContents = new HashSet<ContractsContent>();
            Supplies = new HashSet<Supply>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProviderId { get; set; }

        public virtual Provider Provider { get; set; }
        public virtual ICollection<ContractsContent> ContractsContents { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
