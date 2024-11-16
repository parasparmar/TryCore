using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TryCore.Data;
using TryCore.Persistence;
using IdentityDbContext = Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext;

namespace TryCore.Services
{
    public static class ServiceConfigurations
    {
        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Ops Database
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ProductDbConnection"));
            });
            // Identity Database
            services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")
                    , options => options.MigrationsAssembly("TryCore"));
            });
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<IdentityDbContext>();
        }
    }
}
