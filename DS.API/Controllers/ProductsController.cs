﻿using AutoMapper;
using DS.API.ViewModels.ViewModels.ProductViewModels;
using DS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetCatalogProducts()
        {
            var catalogProductDTOs = await _productsService.GetCatalogProducts();

            var catalogProductViewModels = _mapper.Map<IEnumerable<CatalogProductViewModel>>(catalogProductDTOs);

            return Ok(catalogProductViewModels);
        }
    }
}
