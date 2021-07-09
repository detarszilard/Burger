using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Burger.Common.EntityFrameworkCore.ResourceFilters;
using Burger.Common.EntityFrameworkCore.Stores;
using Burger.Services.Restaurants.Domain.Aggregates.RestaurantAggregate;
using Microsoft.EntityFrameworkCore;

namespace Burger.Services.Restaurants.Infrastructure.Stores
{
    public class RestaurantStore : EntityStore<RestaurantContext, Restaurant>
    {
        public RestaurantStore(RestaurantContext context, IResourceFilter<Restaurant> resourceFilter)
            : base(context, resourceFilter)
        {
        }

        public override Task<Restaurant> GetEntityAsync(string id, CancellationToken cancellationToken = default, bool skipAuthorization = false)
        {
            return GetQuery()
                .Include(r => r.OpeningHours)
                .Include(r => r.Menu)
                .SingleOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        public IQueryable<Restaurant> GetQueryable(bool skipAuthorization = false)
        {
            return GetQuery(skipAuthorization).AsNoTracking();
        }
    }
}
