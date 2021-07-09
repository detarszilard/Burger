using Burger.Services.Restaurants.Domain.Aggregates.RestaurantAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Burger.Services.Restaurants.Infrastructure.EntityConfigurations
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Description).IsRequired();
            builder.Property(b => b.PictureUrl).IsRequired();
        }
    }
}
