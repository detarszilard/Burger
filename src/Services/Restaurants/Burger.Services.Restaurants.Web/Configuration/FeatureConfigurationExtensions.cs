using Burger.Common.EntityFrameworkCore.Behaviors;
using Burger.Common.EntityFrameworkCore.Stores;
using Burger.Services.Restaurants.Application.Commands;
using Burger.Services.Restaurants.Domain.Aggregates.RestaurantAggregate;
using Burger.Services.Restaurants.Infrastructure.Stores;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FeatureConfigurationExtensions
    {
        public static IServiceCollection ConfigureFeature(this IServiceCollection services)
        {
            services.AddScoped<IEntityStore<Restaurant>, RestaurantStore>();
            services.AddScoped<IEntityStore<Restaurant>, RestaurantStore>();

            services.AddMediatR(typeof(AddReviewCommand).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

            return services;
        }
    }
}
