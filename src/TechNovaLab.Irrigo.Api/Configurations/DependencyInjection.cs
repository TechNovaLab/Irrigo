using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using TechNovaLab.Irrigo.Api.Endpoints.Interfaces;

namespace TechNovaLab.Irrigo.Api.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
           => services
            .AddEndpointsApiExplorer()
            //.AddSwaggerGen()
            .AddOpenApiGen()
            .AddProblemDetails()
            .AddEndpoints();
        //.AddExceptionHandler<GlobalExceptionHandler>()

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

        //private static IServiceCollection AddSwagger(this IServiceCollection services)
        //{

        //}

        private static IServiceCollection AddOpenApiGen(this IServiceCollection services)
        {
            services.AddOpenApi();

            return services;
        }
    }
}
