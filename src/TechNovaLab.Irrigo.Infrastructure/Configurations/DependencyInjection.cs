using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TechNovaLab.Irrigo.Application.Abstractions.Authentication;
using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.Infrastructure.Database.Contexts;
using TechNovaLab.Irrigo.Infrastructure.Database.Conventions.Extensions;
using TechNovaLab.Irrigo.Infrastructure.Database.Repositories;
using TechNovaLab.Irrigo.Infrastructure.HealthChecks;
using TechNovaLab.Irrigo.Infrastructure.Providers;
using TechNovaLab.Irrigo.Infrastructure.Security.Authentication;
using TechNovaLab.Irrigo.Infrastructure.Security.Authorization;
using TechNovaLab.Irrigo.SharedKernel.Providers;
using static TechNovaLab.Irrigo.Infrastructure.Security.Authentication.ClaimsPrincipalExtensions;

namespace TechNovaLab.Irrigo.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddServices()
                .AddDatabase(configuration)
                .AddInternalHealthChecks()
                .AddAuthenticationInternal(configuration)
                .AddAuthorizationInternal();

        private static IServiceCollection AddServices(this IServiceCollection services)
            => services
                .AddSingleton<IDateTimeProvider, DateTimeProvider>();

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<ApplicationDbContext>(options => options
               .UseNpgsql(connectionString, npgsqlOptions => npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Default))
               .UseSnakeCaseNamingConvention());

            services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static IServiceCollection AddInternalHealthChecks(this IServiceCollection services)
        {
            services
                .AddHealthChecks()
                .AddCheck<DatabaseHealthCheck>("Database");
            
            return services;
        }

        private static IServiceCollection AddAuthenticationInternal(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!));
                    option.RequireHttpsMetadata = false;
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = signingKey,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        ClockSkew = TimeSpan.Zero,
                        RequireSignedTokens = true,
                        RequireExpirationTime = true
                    };
                });

            services.AddHttpContextAccessor();
            services.AddScoped<IUserContext, UserContext>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ITokenProvider, TokenProvider>();

            return services;
        }
        
        private static IServiceCollection AddAuthorizationInternal(this IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddScoped<PermissionProvider>();
            services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddTransient<IAuthorizationPolicyProvider, RoleAndPermissionAuthorizationPolicyProvider>();

            return services;
        }
    }
}
