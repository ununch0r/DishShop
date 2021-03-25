﻿using AutoMapper;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.ProductDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DS.Services.Services
{
    public class ProductsService : IProductsService
    {
        private readonly DishShopContext _dishShopContext;
        private readonly IMapper _mapper;

        public ProductsService(DishShopContext dishShopContext, IMapper mapper)
        {
            _dishShopContext = dishShopContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CatalogProductDTO>> GetCatalogProductsAsync()
        {
            var productEntities = await _dishShopContext.Products
                .Include(product => product.Category)
                .Include(product => product.Producer)
                .ThenInclude(producer => producer.Country)
                .Include(product => product.ProductsCharacteristics)
                    .ThenInclude(productCharacteristic => productCharacteristic.Characteristic)
                        .ThenInclude(characteristic => characteristic.ValueType)
                .AsNoTracking()
                .ToListAsync();

            var productDTOs = _mapper.Map<IEnumerable<CatalogProductDTO>>(productEntities);

            return productDTOs;
        }

        public async Task<IEnumerable<CatalogProductDTO>> GetCatalogProductsByCategoryIdAsync(int id)
        {
            var productEntities = await _dishShopContext.Products
                .Include(product => product.Category)
                .Include(product => product.Producer)
                .ThenInclude(producer => producer.Country)
                .Include(product => product.ProductsCharacteristics)
                .ThenInclude(productCharacteristic => productCharacteristic.Characteristic)
                .ThenInclude(characteristic => characteristic.ValueType)
                .AsNoTracking()
                .Where(product => product.CategoryId == id)
                .ToListAsync();

            var productDTOs = _mapper.Map<IEnumerable<CatalogProductDTO>>(productEntities);

            return productDTOs;
        }
    }
}