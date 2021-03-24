using DS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DS.API.IoC.Extensions
{
    public static class AddDatabaseContextExtension
    {
        public static void AddDatabaseContext(this IServiceCollection services)
        {
            services.AddDbContext<DishShopContext>(options => options
                .UseSqlServer("Server=DESKTOP-6UER13R;Database=DishShop;Trusted_Connection=True;"));
        }
    }
}
