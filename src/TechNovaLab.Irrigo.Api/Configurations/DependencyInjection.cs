namespace TechNovaLab.Irrigo.Api.Configurations
{
    public static class DependencyInjection
    {
        //public static IServiceCollection AddApplication(this IServiceCollection services) =>
        //    services;

        public static IServiceCollection AddPresentation(this IServiceCollection services)
           => services
               .AddEndpointsApiExplorer()
               .AddSwaggerGen()
               //.AddExceptionHandler<GlobalExceptionHandler>()
               .AddProblemDetails();

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
            => services;
    }
}
