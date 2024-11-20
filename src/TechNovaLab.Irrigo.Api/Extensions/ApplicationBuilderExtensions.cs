namespace TechNovaLab.Irrigo.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerWithUI(this WebApplication app)
        {
            IConfiguration configuration = app.Configuration;
            var projectName = configuration.GetValue<string>("Project:Name");
            var projectVersion = configuration.GetValue<string>("Project:Version");

            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint($"/swagger/v{projectVersion}/swagger.json", $"{projectName} - [v{projectVersion}]");
                setup.RoutePrefix = string.Empty;
            });

            return app;
        }         
    }
}
