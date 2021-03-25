using DS.Services.DTO.DTOs.CountryDTOs;

namespace DS.Services.DTO.DTOs.ProducerDTOs
{
    public class ProductNestedProducerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CountryDTO Country { get; set; }
    }
}
