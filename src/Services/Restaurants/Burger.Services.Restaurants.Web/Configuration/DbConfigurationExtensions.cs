using Burger.Services.Restaurants.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DbConfigurationExtensions
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(RestaurantContext).Assembly.FullName;

            services.AddDbContextPool<RestaurantContext>(options =>
            {
                options
                    .UseNpgsql(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly))
                    .UseSnakeCaseNamingConvention()
                    .EnableSensitiveDataLogging(environment.IsDevelopment());
            });
            services.AddScoped<DbContext>(sp => sp.GetService<RestaurantContext>());

            return services;
        }
    }
}
