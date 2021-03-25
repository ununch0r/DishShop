using System.Collections.Generic;
using DS.Services.DTO.DTOs.ProductDTOs;

namespace DS.Services.Interfaces.Interfaces
{
    public interface IProductsServiceInterface
    {
        IEnumerable<CatalogProductDTO> GetCatalogProducts();
    }
}
