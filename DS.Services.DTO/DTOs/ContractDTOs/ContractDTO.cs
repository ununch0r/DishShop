using DS.Services.DTO.DTOs.ContractContentDTOs;
using DS.Services.DTO.DTOs.ProviderDTOs;
using System;
using System.Collections.Generic;

namespace DS.Services.DTO.DTOs.ContractDTOs
{
    public class ContractDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ProviderNestedInContractDTO Provider { get; set; }
        public IEnumerable<ContractContentDTO> ContractsContents { get; set; }
    }
}
