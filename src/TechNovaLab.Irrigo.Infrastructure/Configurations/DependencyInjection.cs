using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TechNovaLab.Irrigo.Application.Abstractions.Authentication;
using TechNovaLab.Irrigo.Application.Abstractions.Data;
using TechNovaLab.Irrigo.Domain.Repositories;
using TechNovaLab.Irrigo.Infrastructure.Database.Contexts;
using TechNovaLab.Irrigo.Infrastructure.Database.Repositories;
using TechNovaLab.Irrigo.Infrastructure.HealthChecks;
using TechNovaLab.Irrigo.Infrastructure.Providers;
using TechNovaLab.Irrigo.Infrastructure.Security.Authentication;
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
                .AddAuthentication(configuration)
                .AddAuthorization(configuration);

        private static IServiceCollection AddServices(this IServiceCollection services)
            => services
                .AddSingleton<IDateTimeProvider, DateTimeProvider>();

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Database");
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(connectionString, sqlOptions =>
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null)));

            //services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
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

        private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
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
        
        private static IServiceCollection AddAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Viewer", policy => policy.RequireClaim("rol", Role.Viewer.ToString()));
            //    options.AddPolicy("All", policy => policy.RequireClaim("rol", Role.All.ToString()));
            //});

            return services;
        }
    }
}
