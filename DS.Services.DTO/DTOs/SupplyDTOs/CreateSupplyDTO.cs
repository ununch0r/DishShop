using System;
using System.Collections.Generic;
using System.Text;
using DS.Services.DTO.DTOs.SupplyContentDTOs;

namespace DS.Services.DTO.DTOs.SupplyDTOs
{
    public class CreateSupplyDTO
    {
        public int ContractId { get; set; }
        public int EmployeeId { get; set; }
        public int ShopId { get; set; }

        public IEnumerable<CreateSupplyContentDTO> SuppliesContents { get; set; }
    }
}
