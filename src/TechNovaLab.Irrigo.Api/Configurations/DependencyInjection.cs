using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using TechNovaLab.Irrigo.Api.Endpoints;
using TechNovaLab.Irrigo.Api.Infrastructure;

namespace TechNovaLab.Irrigo.Api.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services) =>
            services
                .AddExceptionHandler<GlobalExceptionHandler>()
                .AddEndpointsApiExplorer()
                .AddProblemDetails()
                .AddEndpoints();

        private static IServiceCollection AddEndpoints(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            ServiceDescriptor[] serviceDescriptors = assembly.DefinedTypes
                .Where(type => type is { IsAbstract: false, IsInterface: false } && type.IsAssignableTo(typeof(IEndpoint)))
                .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
                .ToArray();

            services.TryAddEnumerable(serviceDescriptors);

            return services;
        }
    }
}
