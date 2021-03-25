using System;
using System.Collections.Generic;
using DS.Services.DTO.DTOs.ContractContentDTOs;

namespace DS.Services.DTO.DTOs.ContractDTOs
{
    public class CreateContractDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProviderId { get; set; }

        public  IEnumerable<CreateContractContentDTO> ContractsContents { get; set; }
    }
}
