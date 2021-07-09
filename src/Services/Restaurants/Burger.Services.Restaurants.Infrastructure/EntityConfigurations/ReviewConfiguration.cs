using Burger.Services.Restaurants.Domain.Aggregates.ReviewAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Burger.Services.Restaurants.Infrastructure.EntityConfigurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(r => r.UserId).IsRequired();
            builder.Property(r => r.MenuItemId).IsRequired();
            builder.Property(r => r.Description).IsRequired(false);
            builder.Property(r => r.PictureUrl).IsRequired(false);

            builder.OwnsOne(r => r.Score,
                sb =>
                {
                    sb.Property(s => s.Taste).IsRequired();
                    sb.Property(s => s.Texture).IsRequired();
                    sb.Property(s => s.VisualPresentation).IsRequired();
                }
            );
        }
    }
}
