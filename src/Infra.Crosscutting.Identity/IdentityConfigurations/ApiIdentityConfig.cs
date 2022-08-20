using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Identity.Jwt;

namespace Infra.Crosscutting.Identity.IdentityConfigurations
{
    public static class ApiIdentityConfig
    {
        public static void AddApiIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityEntityFrameworkContextConfiguration(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("Infra.Crosscutting.Identity.IdentityConfigurations")));

            // Default Identity configuration from NetDevPack.Identity
            services.AddIdentityConfiguration();

            // Default JWT configuration from NetDevPack.Identity
            services.AddJwtConfiguration(configuration, "AppSettings");
        }
    }
}
