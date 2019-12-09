using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProxyApiService.Installers
{
    public static class InstallerExtentions
    {
        public static void InstallServices(this IServiceCollection services, IConfiguration configuration)
        {
            new DbInstaller().InstallServices(services, configuration);
            new MvcInstaller().InstallServices(services, configuration);
        }
    }
}