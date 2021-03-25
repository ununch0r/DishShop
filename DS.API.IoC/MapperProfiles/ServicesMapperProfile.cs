using AutoMapper;
using DS.API.ViewModels.ViewModels.CategoryViewModels;
using DS.API.ViewModels.ViewModels.CharacteristicViewModels;
using DS.API.ViewModels.ViewModels.ProductCharacteristicViewModels;
using DS.API.ViewModels.ViewModels.ProductViewModels;
using DS.Domain.Entities.Entities;
using DS.Services.DTO.DTOs.CategoryDTOs;
using DS.Services.DTO.DTOs.CharacteristicDTOs;
using DS.Services.DTO.DTOs.CountryDTOs;
using DS.Services.DTO.DTOs.ProducerDTOs;
using DS.Services.DTO.DTOs.ProductCharacteristicDTOs;
using DS.Services.DTO.DTOs.ProductDTOs;
using DS.Services.DTO.DTOs.ValueTypeDTOs;

namespace DS.API.IoC.MapperProfiles
{
    public class ServicesMapperProfile : Profile
    {
        public ServicesMapperProfile()
        {
            AllowNullCollections = true;

            CreateMap<Product, CatalogProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Producer, ProductNestedProducerDTO>();
            CreateMap<Country, CountryDTO>();
            CreateMap<ProductsCharacteristic, ProductCharacteristicDTO>();
            CreateMap<Characteristic, CharacteristicDTO>();
            CreateMap<ValueType, ValueTypeDTO>();

            CreateMap<CreateCharacteristicViewModel, CreateCharacteristicDTO>();
            CreateMap<CreateCategoryViewModel, CreateCategoryDTO>();

            CreateMap<CreateProductViewModel, CreateProductDTO>();
            CreateMap<CreateProductCharacteristicViewModel, CreateProductCharacteristicDTO>();
        }
    }
}
