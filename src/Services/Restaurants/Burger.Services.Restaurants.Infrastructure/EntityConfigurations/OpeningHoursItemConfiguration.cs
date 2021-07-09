using Burger.Services.Restaurants.Domain.Aggregates.RestaurantAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Burger.Services.Restaurants.Infrastructure.EntityConfigurations
{
    public class OpeningHoursItemConfiguration : IEntityTypeConfiguration<OpeningHoursItem>
    {
        public void Configure(EntityTypeBuilder<OpeningHoursItem> builder)
        {
            builder.Property(o => o.Day)
                .IsRequired()
                .HasConversion<string>();

            builder.OwnsOne(o => o.OpeningTime,
                tb =>
                {
                    tb.Property(t => t.Hour).IsRequired();
                    tb.Property(t => t.Minute).IsRequired();
                }
            );

            builder.OwnsOne(o => o.ClosingTime,
                tb =>
                {
                    tb.Property(t => t.Hour).IsRequired();
                    tb.Property(t => t.Minute).IsRequired();
                }
            );
        }
    }
}
