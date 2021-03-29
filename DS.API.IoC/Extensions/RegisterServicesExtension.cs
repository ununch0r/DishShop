using DS.Services.Interfaces.Interfaces;
using DS.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DS.API.IoC.Extensions
{
    public static class RegisterServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<ICharacteristicService, CharacteristicsService>();
            services.AddTransient<IProvidersService, ProvidersService>();
            services.AddTransient<IContractsService, ContractsService>();
            services.AddTransient<IShopsService, ShopsService>();
            services.AddTransient<IProducersService, ProducersService>();
            services.AddTransient<ISuppliesService, SuppliesService>();
        }
    }
}
