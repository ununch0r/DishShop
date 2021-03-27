using System.Collections.Generic;
using DS.Services.DTO.DTOs.CategoryDTOs;
using DS.Services.DTO.DTOs.ProducerDTOs;
using DS.Services.DTO.DTOs.ProductCharacteristicDTOs;

namespace DS.Services.DTO.DTOs.ProductDTOs
{
    public class CatalogProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ScanCode { get; set; }

        public CategoryDTO Category { get; set; }
        public ProducerDTO Producer { get; set; }
        public IEnumerable<ProductCharacteristicDTO> ProductsCharacteristics { get; set; }
    }
}
