using DS.Services.DTO.DTOs.CharacteristicDTOs;

namespace DS.Services.DTO.DTOs.ProductCharacteristicDTOs
{
    public class ProductCharacteristicDTO
    {
        public CharacteristicDTO Characteristic { get; set; }
        public decimal? Value { get; set; }
    }
}
