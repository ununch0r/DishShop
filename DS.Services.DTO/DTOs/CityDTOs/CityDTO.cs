using DS.Services.DTO.DTOs.CountryDTOs;

namespace DS.Services.DTO.DTOs.CityDTOs
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountryDTO Country { get; set; }
    }
}
