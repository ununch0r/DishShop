using AutoMapper;

namespace DS.API.IoC.MapperProfiles
{
    public class ServicesMapperProfile : Profile
    {
        public ServicesMapperProfile()
        {
            AllowNullCollections = true;
        }
    }
}
