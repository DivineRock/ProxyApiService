using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProxyApiService.Data;
using ProxyApiService.Services;

namespace ProxyApiService.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<DataContext>();
            services.AddScoped<IProxyService, ProxyService>();
        }
    }
}