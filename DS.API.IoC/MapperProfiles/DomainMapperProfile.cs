using AutoMapper;
using DS.Domain.Entities.Entities;
using DS.Services.DTO.DTOs.CategoryDTOs;
using DS.Services.DTO.DTOs.CharacteristicDTOs;

namespace DS.API.IoC.MapperProfiles
{
    public class DomainMapperProfile : Profile
    {
        public DomainMapperProfile()
        {
            AllowNullCollections = true;

            CreateMap<CreateCharacteristicDTO, Characteristic>();
            CreateMap<CreateCategoryDTO, Category>();
        }
    }
}
