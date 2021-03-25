using AutoMapper;
using DS.API.ViewModels.ViewModels.CategoryViewModels;
using DS.Services.DTO.DTOs.CategoryDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DS.API.Controllers
{
    [Route("api/categories")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(IMapper mapper, ICategoriesService categoriesService)
        {
            _mapper = mapper;
            _categoriesService = categoriesService;
        }

        [HttpPost]
        public async Task<IActionResult> GetCatalogProductsAsync(
            [FromBody][Required] CreateCategoryViewModel createCategoryViewModel
        )
        {
            var createCategoryDTO = _mapper.Map<CreateCategoryDTO>(createCategoryViewModel);

            var createdCategoryDTO = await _categoriesService.CreateCategoryAsync(createCategoryDTO);
            var createdCategoryViewModel = _mapper.Map<CategoryViewModel>(createdCategoryDTO);

            return Ok(createdCategoryViewModel);
        }
    }
}
