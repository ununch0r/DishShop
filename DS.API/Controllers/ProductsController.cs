using AutoMapper;
using DS.API.ViewModels.ViewModels.ProductViewModels;
using DS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DS.Services.DTO.DTOs.ProductDTOs;

namespace DS.API.Controllers
{
    [Route("api/products")]
    [Produces("application/json")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public ProductsController(IProductsService productsService, IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCatalogProductsAsync()
        {
            var catalogProductDTOs = await _productsService.GetCatalogProductsAsync();

            var catalogProductViewModels = _mapper.Map<IEnumerable<CatalogProductViewModel>>(catalogProductDTOs);

            return Ok(catalogProductViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatalogProductsByCategoryIdAsync(int id)
        {
            var catalogProductDTOs = await _productsService.GetCatalogProductsByCategoryIdAsync(id);

            var catalogProductViewModels = _mapper.Map<IEnumerable<CatalogProductViewModel>>(catalogProductDTOs);

            return Ok(catalogProductViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(
            [FromBody] [Required] CreateProductViewModel createProductViewModel
            )
        {
            var createProductDTO = _mapper.Map<CreateProductDTO>(createProductViewModel);

            var createdProductDTO = await _productsService.CreateProductAsync(createProductDTO);
            var createdProductViewModel = _mapper.Map<CatalogProductViewModel>(createdProductDTO);

            return Ok(createdProductViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductAsync(
            int id,
            [FromBody][Required] CreateProductViewModel updateProductViewModel
        )
        {
            var updateProductDTO = _mapper.Map<CreateProductDTO>(updateProductViewModel);

            var updatedProductDTO = await _productsService.UpdateProductAsync(id,updateProductDTO);
            var updatedProductViewModel = _mapper.Map<CatalogProductViewModel>(updatedProductDTO);

            return Ok(updatedProductViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductByIdAsync(int id)
        {
            await _productsService.DeleteProductByIdAsync(id);

            return NoContent();
        }

    }
}
