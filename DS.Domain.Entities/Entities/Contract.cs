using System;
using System.Collections.Generic;

namespace DS.Domain.Entities.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProviderId { get; set; }

        public Provider Provider { get; set; }
        public IEnumerable<ContractContent> ContractContents { get; set; }
        public IEnumerable<Supply> Supplies { get; set; }

    }
}
