using System.Linq;
using Burger.Common.EntityFrameworkCore.ResourceFilters;
using Burger.Common.EntityFrameworkCore.Stores;
using Burger.Services.Restaurants.Domain.Aggregates.ReviewAggregate;
using Microsoft.EntityFrameworkCore;

namespace Burger.Services.Restaurants.Infrastructure.Stores
{
    public class ReviewStore : EntityStore<RestaurantContext, Review>
    {
        public ReviewStore(RestaurantContext context, IResourceFilter<Review> resourceFilter)
            : base(context, resourceFilter)
        {
        }

        public IQueryable<Review> GetQueryable(bool skipAuthorization = false)
        {
            return GetQuery(skipAuthorization).AsNoTracking();
        }
    }
}
