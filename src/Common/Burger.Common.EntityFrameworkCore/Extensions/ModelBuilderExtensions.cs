using System.Linq;
using System.Linq.Expressions;
using Burger.Common.EntityFrameworkCore.ValueGenerators;
using Burger.Common.SeedWork;

namespace Microsoft.EntityFrameworkCore
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyGlobalIdCofiguration(this ModelBuilder builder)
        {
            var entityTypes = builder.Model
                .GetEntityTypes()
                .Where(et => typeof(IEntity).IsAssignableFrom(et.ClrType));

            var idPropertyName = nameof(IEntity.Id);

            foreach (var entityType in entityTypes)
            {
                var entityTypeBuilder = builder.Entity(entityType.ClrType);

                entityTypeBuilder.HasKey(idPropertyName);
                entityTypeBuilder.Property(idPropertyName)
                    .ValueGeneratedOnAdd()
                    .HasValueGenerator<GuidStringGenerator>();
            }
        }

        public static void ApplySoftDeleteConfiguration(this ModelBuilder builder)
        {
            var softDeleteTypes = builder.Model
                .GetEntityTypes()
                .Where(et => typeof(ISoftDelete).IsAssignableFrom(et.ClrType));

            if (!softDeleteTypes.Any())
            {
                return;
            }

            var isDeletedPropertyName = nameof(ISoftDelete.IsDeleted);

            foreach (var entityType in softDeleteTypes)
            {
                var expressionParam = Expression.Parameter(entityType.ClrType);
                var filterExpression = Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(expressionParam, isDeletedPropertyName),
                        Expression.Constant(false)),
                    expressionParam);

                builder
                    .Entity(entityType.ClrType)
                    .HasQueryFilter(filterExpression);

                builder
                    .Entity(entityType.ClrType)
                    .Property(isDeletedPropertyName);
            }
        }
    }
}
