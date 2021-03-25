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

        public ProductNestedCategoryDTO Category { get; set; }
        public ProductNestedProducerDTO Producer { get; set; }
        public IEnumerable<ProductCharacteristicDTO> ProductCharacteristics { get; set; }
    }
}
