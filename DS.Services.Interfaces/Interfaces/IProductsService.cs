using System.Collections.Generic;
using System.Threading.Tasks;
using DS.Services.DTO.DTOs.ProductDTOs;

namespace DS.Services.Interfaces.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<CatalogProductDTO>> GetCatalogProductsAsync();
        Task<IEnumerable<CatalogProductDTO>> GetCatalogProductsByCategoryIdAsync(int id);
        Task<CatalogProductDTO> CreateProductAsync(CreateProductDTO createProductDTO);
        Task<CatalogProductDTO> UpdateProductAsync(int id, CreateProductDTO updateProductDTO);
        Task DeleteProductByIdAsync(int id);
    }
}
