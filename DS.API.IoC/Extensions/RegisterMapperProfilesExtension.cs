using AutoMapper;
using DS.API.IoC.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace DS.API.IoC.Extensions
{
    public static class RegisterMapperProfilesExtension
    {
        public static void RegisterMapperProfiles(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration(c =>
            {
                c.AddProfile<DomainMapperProfile>();
                c.AddProfile<ServicesMapperProfile>();
                c.AddProfile<APIMapperProfile>();
            });
            services.AddTransient(s => configuration.CreateMapper());
        }
	}
}
