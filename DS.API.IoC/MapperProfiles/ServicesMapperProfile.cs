using AutoMapper;
using DS.API.ViewModels.ViewModels.CategoryViewModels;
using DS.API.ViewModels.ViewModels.ContractContentViewModels;
using DS.API.ViewModels.ViewModels.ContractViewModels;
using DS.API.ViewModels.ViewModels.EmployeeViewModels;
using DS.API.ViewModels.ViewModels.ProductCharacteristicViewModels;
using DS.API.ViewModels.ViewModels.ProductViewModels;
using DS.API.ViewModels.ViewModels.ProviderViewModels;
using DS.API.ViewModels.ViewModels.ShopViewModels;
using DS.API.ViewModels.ViewModels.SupplyContentViewModels;
using DS.API.ViewModels.ViewModels.SupplyViewModels;
using DS.API.ViewModels.ViewModels.UtilityViewModels;
using DS.Domain.Entities.Entities;
using DS.Services.DTO.DTOs.CategoryDTOs;
using DS.Services.DTO.DTOs.CharacteristicDTOs;
using DS.Services.DTO.DTOs.CityDTOs;
using DS.Services.DTO.DTOs.ContractContentDTOs;
using DS.Services.DTO.DTOs.ContractDTOs;
using DS.Services.DTO.DTOs.CountryDTOs;
using DS.Services.DTO.DTOs.EmployeeDTOs;
using DS.Services.DTO.DTOs.PositionDTOs;
using DS.Services.DTO.DTOs.ProducerDTOs;
using DS.Services.DTO.DTOs.ProductCharacteristicDTOs;
using DS.Services.DTO.DTOs.ProductDTOs;
using DS.Services.DTO.DTOs.ProviderDTOs;
using DS.Services.DTO.DTOs.ShopAvailabilityDTOs;
using DS.Services.DTO.DTOs.ShopDTOs;
using DS.Services.DTO.DTOs.SupplyContentDTOs;
using DS.Services.DTO.DTOs.SupplyDTOs;
using DS.Services.DTO.DTOs.SupplyStatusDTOs;
using DS.Services.DTO.DTOs.UtilityDTOs;
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
            CreateMap<Producer, ProducerDTO>();
            CreateMap<Country, CountryDTO>();
            CreateMap<ProductsCharacteristic, ProductCharacteristicDTO>();
            CreateMap<Characteristic, CharacteristicDTO>();
            CreateMap<ValueType, ValueTypeDTO>();
            CreateMap<City,CityDTO>();
            CreateMap<Provider, ProviderDTO>();
            CreateMap<Provider, ProviderNestedInContractDTO>();
            CreateMap<Contract, ContractDTO>();
            CreateMap<Contract, ContractNestedInProviderDTO>();
            CreateMap<ContractsContent, ContractContentDTO>();
            CreateMap<SupplyStatus, SupplyStatusDTO>();
            CreateMap<Supply, SupplyDTO>();
            CreateMap<SuppliesContent, SupplyContentDTO>();
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Position, PositionDTO>();
            CreateMap<Shop, ShopDTO>();
            CreateMap<ShopsAvailability, ShopAvailabilityDTO>();
            CreateMap<Employee, ShopNestedEmployeeDTO>();
            CreateMap<Supply, ShopNestedSupplyDTO>();






            CreateMap<CreateCharacteristicViewModel, CreateCharacteristicDTO>();
            CreateMap<CreateCategoryViewModel, CreateCategoryDTO>();
            CreateMap<CreateProductViewModel, CreateProductDTO>();
            CreateMap<CreateProductCharacteristicViewModel, CreateProductCharacteristicDTO>();
            CreateMap<CreateProviderViewModel, CreateProviderDTO>();
            CreateMap<CreateContractContentViewModel, CreateContractContentDTO>();
            CreateMap<CreateContractViewModel, CreateContractDTO>();
            CreateMap<CreateShopViewModel, CreateShopDTO>();
            CreateMap<CreateEmployeeViewModel, CreateEmployeeDTO>();
            CreateMap<CreateSupplyContentViewModel, CreateSupplyContentDTO>();
            CreateMap<CreateSupplyViewModel, CreateSupplyDTO>();
            CreateMap<CreateProducerViewModel, CreateProducerDTO>();
            CreateMap<CreateCityViewModel, CreateCityDTO>();
            CreateMap<CreateCountryViewModel, CreateCountryDTO>();
            CreateMap<CreateCharacteristicViewModel, CreateCharacteristicDTO>();
            CreateMap<CreateValueTypeViewModel, CreateValueTypeDTO>();
        }
    }
}
