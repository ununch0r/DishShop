using DS.Services.DTO.DTOs.ContractDTOs;
using DS.Services.DTO.DTOs.SupplyStatusDTOs;
using System;
using System.Collections.Generic;
using DS.Services.DTO.DTOs.SupplyContentDTOs;

namespace DS.Services.DTO.DTOs.SupplyDTOs
{
    public class SupplyDTO
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateReceived { get; set; }

        public ContractDTO Contract { get; set; }
        //public EmployeeDTO Employee { get; set; }
        //public ShopDTO Shop { get; set; }
        public SupplyStatusDTO Status { get; set; }
        public IEnumerable<SupplyContentDTO> SuppliesContents { get; set; }
    }
}
