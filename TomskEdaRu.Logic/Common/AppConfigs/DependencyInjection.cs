using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TomskEdaRu.Logic.Common.AppConfigs.Main;

namespace TomskEdaRu.Logic.Common.AppConfigs
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppConfigs(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions();

            services.Configure<AnimalConfig>(configuration.GetSection("EntityConfigs:Animal"));

            return services;
        }
    }
}