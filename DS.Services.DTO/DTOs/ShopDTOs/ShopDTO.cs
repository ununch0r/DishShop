using System.Collections.Generic;
using DS.Services.DTO.DTOs.CityDTOs;
using DS.Services.DTO.DTOs.EmployeeDTOs;
using DS.Services.DTO.DTOs.ShopAvailabilityDTOs;
using DS.Services.DTO.DTOs.SupplyDTOs;

namespace DS.Services.DTO.DTOs.ShopDTOs
{
    public class ShopDTO
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetIdentifier { get; set; }
        public string StreetName { get; set; }

        public ShopNestedEmployeeDTO Manager { get; set; }
        public CityDTO City { get; set; }

        public IEnumerable<ShopNestedSupplyDTO> Supplies { get; set; }
        public IEnumerable<ShopAvailabilityDTO> ShopsAvailabilities { get; set; }
        public IEnumerable<ShopNestedEmployeeDTO> Employees { get; set; }
    }
}
