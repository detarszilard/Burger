using Burger.Common.EntityFrameworkCore.Contexts;
using Burger.Services.Restaurants.Domain.Aggregates.RestaurantAggregate;
using Burger.Services.Restaurants.Domain.Aggregates.ReviewAggregate;
using Microsoft.EntityFrameworkCore;

namespace Burger.Services.Restaurants.Infrastructure
{
    public class RestaurantContext : ContextBase<RestaurantContext>
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
        }

        DbSet<Restaurant> Restaurants { get; set; }
        DbSet<Review> Reviews { get; set; }
    }
}
