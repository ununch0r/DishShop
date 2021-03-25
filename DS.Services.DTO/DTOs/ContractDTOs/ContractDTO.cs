using System;
using System.Collections.Generic;
using DS.Services.DTO.DTOs.ContractContentDTOs;
using DS.Services.DTO.DTOs.ProviderDTOs;

namespace DS.Services.DTO.DTOs.ContractDTOs
{
    public class ContractDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ProviderDTO Provider { get; set; }
        public virtual IEnumerable<ContractContentDTO> ContractsContents { get; set; }
    }
}
