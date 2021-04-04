using System;
using AutoMapper;
using DS.Infrastructure.Context;
using DS.Services.DTO.DTOs.ProductDTOs;
using DS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DS.Domain.Entities.Entities;

namespace DS.Services.Services
{
    public class ProductsService : IProductsService
    {
        private readonly DishShopContext _dishShopContext;
        private readonly IMapper _mapper;
        private static readonly Random Random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

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

        public async Task<CatalogProductDTO> CreateProductAsync(CreateProductDTO createProductDTO)
        {
            createProductDTO.ScanCode = RandomString(1000);
            var productEntity = _mapper.Map<Product>(createProductDTO);

            var categoryCharacteristics = productEntity.ProductsCharacteristics
                .Select(productCharacteristic =>
                new CategoriesCharacteristic
                {
                    CategoryId = productEntity.CategoryId,
                    CharacteristicId = productCharacteristic.CharacteristicId
                }).ToList();

            await DeleteExistingCategoryCharacteristicAsync(categoryCharacteristics);

            await _dishShopContext.CategoriesCharacteristics
                .AddRangeAsync(categoryCharacteristics);
            
            await _dishShopContext.AddAsync(productEntity);
            await _dishShopContext.SaveChangesAsync();

            var createdProductEntity = await _dishShopContext.Products
                .Include(product => product.Category)
                .Include(product => product.Producer)
                .ThenInclude(producer => producer.Country)
                .Include(product => product.ProductsCharacteristics)
                .ThenInclude(productCharacteristic => productCharacteristic.Characteristic)
                .ThenInclude(characteristic => characteristic.ValueType)
                .AsNoTracking()
                .SingleOrDefaultAsync(product => product.Id == productEntity.Id);

            var createdProductDTO = _mapper.Map<CatalogProductDTO>(createdProductEntity);
            return createdProductDTO;
        }

        private async Task DeleteExistingCategoryCharacteristicAsync(
            ICollection<CategoriesCharacteristic> categoryCharacteristics)
        {
            var itemsToBeRemoved = new List<CategoriesCharacteristic>();
            foreach (var categoryCharacteristic in categoryCharacteristics)
            {
                var doesExist = await _dishShopContext.CategoriesCharacteristics.AnyAsync(catChar =>
                    catChar.CharacteristicId == categoryCharacteristic.CharacteristicId &&
                    catChar.CategoryId == categoryCharacteristic.CategoryId);
                if (doesExist)
                {
                    itemsToBeRemoved.Add(categoryCharacteristic);
                }
            }

            foreach (var item in itemsToBeRemoved)
            {
                categoryCharacteristics.Remove(item);
            }
        }

        public async Task<CatalogProductDTO> UpdateProductAsync(int id, CreateProductDTO updateProductDTO)
        {
            var productToBeUpdated = await _dishShopContext.Products
                .Include(product => product.ProductsCharacteristics)
                .SingleOrDefaultAsync(product => product.Id == id);
            var newProduct = _mapper.Map<Product>(updateProductDTO);


            productToBeUpdated.CategoryId = newProduct.CategoryId;
            productToBeUpdated.ProducerId = newProduct.ProducerId;
            productToBeUpdated.Price = newProduct.Price;
            productToBeUpdated.Description = newProduct.Description;
            productToBeUpdated.ProductsCharacteristics = newProduct.ProductsCharacteristics;

            await _dishShopContext.SaveChangesAsync();

            var updatedProductDTO = _mapper.Map<CatalogProductDTO>(productToBeUpdated);
            return updatedProductDTO;
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            var productToBeDeleted = await _dishShopContext.Products
                .SingleOrDefaultAsync(product => product.Id == id);

            _dishShopContext.Remove(productToBeDeleted);

            await _dishShopContext.SaveChangesAsync();
        }
    }
}
