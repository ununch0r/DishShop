using DS.Services.DTO.DTOs.ProductDTOs;

namespace DS.Services.DTO.DTOs.ShopAvailabilityDTOs
{
    public class ShopAvailabilityDTO
    {
        public int Amount { get; set; }

        public CatalogProductDTO Product { get; set; }
    }
}
