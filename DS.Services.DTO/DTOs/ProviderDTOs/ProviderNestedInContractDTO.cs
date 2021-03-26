using DS.Services.DTO.DTOs.CityDTOs;

namespace DS.Services.DTO.DTOs.ProviderDTOs
{
    public class ProviderNestedInContractDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public CityDTO City { get; set; }
    }
}
