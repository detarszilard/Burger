using Burger.Services.Restaurants.Domain.Aggregates.RestaurantAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Burger.Services.Restaurants.Infrastructure.EntityConfigurations
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.Property(r => r.Name).IsRequired();
            builder.Property(r => r.Description).IsRequired();
            builder.Property(r => r.Location).IsRequired();

            builder.HasMany(r => r.Menu)
                .WithOne();

            builder.HasMany(r => r.OpeningHours)
                .WithOne();
        }
    }
}
