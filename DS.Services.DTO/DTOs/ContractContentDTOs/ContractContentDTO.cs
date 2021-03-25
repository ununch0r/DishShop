using DS.Services.DTO.DTOs.ProductDTOs;

namespace DS.Services.DTO.DTOs.ContractContentDTOs
{
    public class ContractContentDTO
    {
        public decimal PricePerUnit { get; set; }

        public CatalogProductDTO Product { get; set; }
    }
}
