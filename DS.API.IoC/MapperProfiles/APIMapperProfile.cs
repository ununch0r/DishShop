using AutoMapper;
using DS.API.ViewModels.ViewModels.CategoryViewModels;
using DS.API.ViewModels.ViewModels.CharacteristicViewModels;
using DS.API.ViewModels.ViewModels.CityViewModels;
using DS.API.ViewModels.ViewModels.ContractContentViewModels;
using DS.API.ViewModels.ViewModels.ContractViewModels;
using DS.API.ViewModels.ViewModels.CountryViewModels;
using DS.API.ViewModels.ViewModels.ProducerViewModels;
using DS.API.ViewModels.ViewModels.ProductCharacteristicViewModels;
using DS.API.ViewModels.ViewModels.ProductViewModels;
using DS.API.ViewModels.ViewModels.ProviderViewModels;
using DS.API.ViewModels.ViewModels.SupplyContentViewModels;
using DS.API.ViewModels.ViewModels.SupplyStatusViewModels;
using DS.API.ViewModels.ViewModels.SupplyViewModels;
using DS.API.ViewModels.ViewModels.ValueTypeViewModels;
using DS.Domain.Entities.Entities;
using DS.Services.DTO.DTOs.CategoryDTOs;
using DS.Services.DTO.DTOs.CharacteristicDTOs;
using DS.Services.DTO.DTOs.CityDTOs;
using DS.Services.DTO.DTOs.ContractContentDTOs;
using DS.Services.DTO.DTOs.ContractDTOs;
using DS.Services.DTO.DTOs.CountryDTOs;
using DS.Services.DTO.DTOs.ProducerDTOs;
using DS.Services.DTO.DTOs.ProductCharacteristicDTOs;
using DS.Services.DTO.DTOs.ProductDTOs;
using DS.Services.DTO.DTOs.ProviderDTOs;
using DS.Services.DTO.DTOs.SupplyContentDTOs;
using DS.Services.DTO.DTOs.SupplyDTOs;
using DS.Services.DTO.DTOs.SupplyStatusDTOs;
using DS.Services.DTO.DTOs.ValueTypeDTOs;

namespace DS.API.IoC.MapperProfiles
{
    public class APIMapperProfile : Profile
    {
        public APIMapperProfile()
        {
            AllowNullCollections = true;

            CreateMap<CatalogProductDTO, CatalogProductViewModel>();
            CreateMap<CategoryDTO, CategoryViewModel>();
            CreateMap<ProductNestedProducerDTO, ProductNestedProducerViewModel>();
            CreateMap<CountryDTO, CountryViewModel>();
            CreateMap<ProductCharacteristicDTO, ProductCharacteristicViewModel>();
            CreateMap<CharacteristicDTO, CharacteristicViewModel>();
            CreateMap<ValueTypeDTO, ValueTypeViewModel>();

            CreateMap<CityDTO, CityViewModel>();
            CreateMap<ProviderDTO, ProviderViewModel>();
            CreateMap<ProviderNestedInContractDTO, ProviderNestedInContractViewModel>();

            CreateMap<ContractDTO, ContractViewModel>();
            CreateMap<ContractNestedInProviderDTO, ContractNestedInProviderViewModel>();
            CreateMap<ContractContentDTO, ContractContentViewModel>();

            CreateMap<SupplyStatusDTO, SupplyStatusViewModel>();
            CreateMap<SupplyDTO, SupplyViewModel>();
            CreateMap<SupplyContentDTO, SupplyContentViewModel>();
        }
    }
}
