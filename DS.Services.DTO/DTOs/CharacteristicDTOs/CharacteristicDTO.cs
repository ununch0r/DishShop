using DS.Services.DTO.DTOs.ValueTypeDTOs;

namespace DS.Services.DTO.DTOs.CharacteristicDTOs
{
    public class CharacteristicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ValueTypeDTO ValueType { get; set; }
    }
}
