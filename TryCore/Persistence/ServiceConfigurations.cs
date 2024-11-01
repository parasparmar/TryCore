using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TryCore.Persistence
{
    public static class ServiceConfigurations
    {
        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Ops Database
            services.AddDbContext<ProductDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("AppDataConnection"));
                });
            // Identity Database
            services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")
                    , options => options.MigrationsAssembly("TryCore"));
            });

        }
    }
}
