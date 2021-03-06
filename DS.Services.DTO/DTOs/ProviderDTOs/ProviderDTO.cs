using System.Collections.Generic;
using DS.Services.DTO.DTOs.CityDTOs;
using DS.Services.DTO.DTOs.ContractDTOs;

namespace DS.Services.DTO.DTOs.ProviderDTOs
{
    public class ProviderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public CityDTO City { get; set; }
        public IEnumerable<ContractNestedInProviderDTO> Contracts { get; set; }
    }
}
