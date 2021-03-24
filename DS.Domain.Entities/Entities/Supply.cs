using System;
using System.Collections.Generic;

namespace DS.Domain.Entities.Entities
{
    public class Supply
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateReceived { get; set; }
        public int ContractId { get; set; }
        public int EmployeeId { get; set; }
        public int ShopId { get; set; }
        public int StatusId { get; set; }

        public Contract Contract { get; set; }
        public Employee Employee { get; set; }
        public Shop Shop { get; set; }
        public SupplyStatus SupplyStatus { get; set; }
        public IEnumerable<SupplyContent> SupplyContents { get; set; }
    }
}
