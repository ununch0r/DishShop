using AutoMapper;

namespace DS.API.IoC.MapperProfiles
{
    public class APIMapperProfile : Profile
    {
        public APIMapperProfile()
        {
            AllowNullCollections = true;
        }
    }
}
