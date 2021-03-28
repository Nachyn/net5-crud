using System.Reflection;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TomskEdaRu.Logic.Common.AppConfigs;
using TomskEdaRu.Logic.Common.Behaviours;
using TomskEdaRu.Logic.Common.Mappings;

namespace TomskEdaRu.Logic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLogic(this IServiceCollection services,
            IConfiguration configuration)
        {
            var mapperConfiguration =
                new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            mapperConfiguration.AssertConfigurationIsValid();
            services.AddSingleton(mapperConfiguration.CreateMapper());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddAppConfigs(configuration);
            
            return services;
        }
    }
}