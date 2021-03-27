using System.Collections.Generic;
using DS.Services.DTO.DTOs.CategoryDTOs;
using System.Threading.Tasks;

namespace DS.Services.Interfaces.Interfaces
{
    public interface ICategoriesService
    {
        Task<CategoryDTO> CreateCategoryAsync(CreateCategoryDTO createCategoryDto);
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
    }
}
