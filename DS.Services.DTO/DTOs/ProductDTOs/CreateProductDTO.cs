using System.Collections.Generic;
using DS.Services.DTO.DTOs.ProductCharacteristicDTOs;

namespace DS.Services.DTO.DTOs.ProductDTOs
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ScanCode { get; set; }
        public int ProducerId { get; set; }
        public int CategoryId { get; set; }

        public IEnumerable<CreateProductCharacteristicDTO> ProductsCharacteristics { get; set; }
    }
}
