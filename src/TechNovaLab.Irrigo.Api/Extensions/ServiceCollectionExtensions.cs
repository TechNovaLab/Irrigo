using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace TechNovaLab.Irrigo.Api.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddSwaggerGenWithAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var projectName = configuration.GetValue<string>("Project:Name");
            var projectVersion = configuration.GetValue<string>("Project:Version");

            services.AddSwaggerGen(setup =>
            {
                //setup.CustomSchemaIds(type => type.Name);
                setup.CustomSchemaIds(id => id.FullName!.Replace('+', '-'));
                setup.SwaggerDoc($"v{projectVersion}", new OpenApiInfo { Title = projectName, Version = projectVersion });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter your JWT token in this field",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT"
                };

                setup.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                };

                setup.AddSecurityRequirement(securityRequirement);
            });

            return services;
        }
    }
}
