using System.Threading.Tasks;
using AutoMapper;
using DS.Domain.Entities.Entities;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.CategoryDTOs;
using DS.Services.Interfaces.Interfaces;

namespace DS.Services.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly DishShopContext _dishShopContext;
        private readonly IMapper _mapper;

        public CategoriesService(IMapper mapper, DishShopContext dishShopContext)
        {
            _mapper = mapper;
            _dishShopContext = dishShopContext;
        }

        public async Task<CategoryDTO> CreateCategoryAsync(CreateCategoryDTO createCategoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(createCategoryDto);

            await _dishShopContext.AddAsync(categoryEntity);
            await _dishShopContext.SaveChangesAsync();

            var createdCategoryDTO = _mapper.Map<CategoryDTO>(categoryEntity);
            return createdCategoryDTO;
        }
    }
}
