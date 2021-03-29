using DS.Services.DTO.DTOs.ProductDTOs;

namespace DS.Services.DTO.DTOs.SupplyContentDTOs
{
    public class SupplyContentDTO
    {
        public CatalogProductDTO Product { get; set; }
        public int Count { get; set; }
    }
}
