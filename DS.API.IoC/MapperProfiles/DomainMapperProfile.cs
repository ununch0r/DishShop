using AutoMapper;

namespace DS.API.IoC.MapperProfiles
{
    public class DomainMapperProfile : Profile
    {
        public DomainMapperProfile()
        {
            AllowNullCollections = true;
        }
    }
}
