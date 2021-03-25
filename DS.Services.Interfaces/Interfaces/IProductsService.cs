using System.Collections.Generic;
using System.Threading.Tasks;
using DS.Services.DTO.DTOs.ProductDTOs;

namespace DS.Services.Interfaces.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<CatalogProductDTO>> GetCatalogProducts();
    }
}
