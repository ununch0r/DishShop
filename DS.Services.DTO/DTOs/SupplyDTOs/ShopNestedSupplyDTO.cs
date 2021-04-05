using System;
using System.Collections.Generic;
using System.Text;
using DS.Services.DTO.DTOs.ContractDTOs;
using DS.Services.DTO.DTOs.EmployeeDTOs;
using DS.Services.DTO.DTOs.ShopDTOs;
using DS.Services.DTO.DTOs.SupplyContentDTOs;
using DS.Services.DTO.DTOs.SupplyStatusDTOs;

namespace DS.Services.DTO.DTOs.SupplyDTOs
{
    public class ShopNestedSupplyDTO
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateReceived { get; set; }

        public ContractDTO Contract { get; set; }
        public EmployeeDTO Employee { get; set; }
        public SupplyStatusDTO Status { get; set; }
        public IEnumerable<SupplyContentDTO> SuppliesContents { get; set; }
    }
}
