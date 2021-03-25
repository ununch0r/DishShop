using System.Collections.Generic;
using AutoMapper;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.ProductDTOs;
using DS.Services.Interfaces.Interfaces;

namespace DS.Services.Services
{
    public class ProductsServiceService : IProductsServiceInterface
    {
        private readonly DishShopContext _dishShopContext;
        private readonly IMapper _mapper;

        public ProductsServiceService(DishShopContext dishShopContext, IMapper mapper)
        {
            _dishShopContext = dishShopContext;
            _mapper = mapper;
        }

        public IEnumerable<CatalogProductDTO> GetCatalogProducts()
        {
            return null;
        }
    }
}
