using DS.Services.DTO.DTOs.CityDTOs;

namespace DS.Services.DTO.DTOs.ShopDTOs
{
    public class ShopDTO
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetIdentifier { get; set; }
        public string StreetName { get; set; }

        public CityDTO City { get; set; }
    }
}
