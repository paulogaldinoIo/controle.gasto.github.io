using Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Service_Api.Configuations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configurations)
        {
            if(services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<BaseDbContext>(options =>
             options.UseSqlServer(configurations.GetConnectionString("DefaultConnection")));

            services.AddDbContext<EventStoreSQLContext>(options =>
                options.UseSqlServer(configurations.GetConnectionString("DefaultConnection")));
        }
    }
}
