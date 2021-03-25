namespace DS.Services.DTO.DTOs.ProductCharacteristicDTOs
{
    public class CreateProductCharacteristicDTO
    {
        public int ProductId { get; set; }
        public int CharacteristicId { get; set; }
        public decimal? Value { get; set; }
    }
}
