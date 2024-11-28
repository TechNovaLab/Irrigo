using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using TechNovaLab.Irrigo.Application.Abstractions.Behaviors;
using TechNovaLab.Irrigo.Application.Services.Crops.Interfaces;

namespace TechNovaLab.Irrigo.Application.Configurations
{
    public static class DependencyInjection
    {
        private const string ServicesNamespace = "TechNovaLab.Irrigo.Application.Services";

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
                config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);
            services.AddServicesFromAssembly();

            return services;
        }

        private static IServiceCollection AddServicesFromAssembly(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            var serviceTypes = assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && type.Namespace != null && type.Namespace.Contains(ServicesNamespace))
                .ToList();

            foreach (var implementationType in serviceTypes)
            {
                var interfaceType = implementationType.GetInterfaces().FirstOrDefault();
                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, implementationType);
                }
            }

            return services;
        }
    }
}