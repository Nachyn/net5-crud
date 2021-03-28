using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TomskEdaRu.Infrastructure.Database;
using TomskEdaRu.Infrastructure.Services.DateTimeService;
using TomskEdaRu.Logic.Common.ExternalServices.Database;
using TomskEdaRu.Logic.Common.ExternalServices.DateTimeService;

namespace TomskEdaRu.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IAppDbContext, AppDbContext>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => { b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName); }));

            services.AddScoped<IAppDbContext>(provider =>
                provider.GetService<AppDbContext>());

            AddServices(services);
            return services;
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}