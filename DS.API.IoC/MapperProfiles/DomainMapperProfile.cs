using AutoMapper;
using DS.API.ViewModels.ViewModels.UtilityViewModels;
using DS.Domain.Entities.Entities;
using DS.Services.DTO.DTOs.CategoryDTOs;
using DS.Services.DTO.DTOs.ContractContentDTOs;
using DS.Services.DTO.DTOs.ContractDTOs;
using DS.Services.DTO.DTOs.EmployeeDTOs;
using DS.Services.DTO.DTOs.ProductCharacteristicDTOs;
using DS.Services.DTO.DTOs.ProductDTOs;
using DS.Services.DTO.DTOs.ProviderDTOs;
using DS.Services.DTO.DTOs.ShopDTOs;
using DS.Services.DTO.DTOs.SupplyContentDTOs;
using DS.Services.DTO.DTOs.SupplyDTOs;
using DS.Services.DTO.DTOs.UtilityDTOs;
using CreateCharacteristicDTO = DS.Services.DTO.DTOs.CharacteristicDTOs.CreateCharacteristicDTO;
using CreateCharacteristicViewModel = DS.API.ViewModels.ViewModels.CharacteristicViewModels.CreateCharacteristicViewModel;

namespace DS.API.IoC.MapperProfiles
{
    public class DomainMapperProfile : Profile
    {
        public DomainMapperProfile()
        {
            AllowNullCollections = true;

            CreateMap<CreateCharacteristicDTO, Characteristic>();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<CreateProductDTO, Product>();
            CreateMap<CreateProductCharacteristicDTO, ProductsCharacteristic>();
            CreateMap<CreateProviderDTO, Provider>();
            CreateMap<CreateContractContentDTO, ContractsContent>();
            CreateMap<CreateContractDTO, Contract>();
            CreateMap<CreateShopDTO, Shop>();
            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<CreateSupplyDTO, Supply>();
            CreateMap<CreateSupplyContentDTO, SuppliesContent>();
            CreateMap<CreateProducerDTO, Producer>();
            CreateMap<CreateCityDTO, City>();
            CreateMap<CreateCountryDTO, Country>();
            CreateMap<CreateCharacteristicDTO, Characteristic>();
            CreateMap<CreateValueTypeDTO, ValueType>();
        }
    }
}
