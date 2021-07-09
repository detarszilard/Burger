using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Burger.Services.Restaurants.Application.ResponseModels;
using Burger.Services.Restaurants.Infrastructure.Stores;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace Burger.Services.Restaurants.Application.Queries
{
    public class GetNearbyRestaurantsQueryHandler : IRequestHandler<GetNearbyRestaurantsQuery, IEnumerable<RestaurantModel>>
    {
        private readonly RestaurantStore _restaurantStore;

        public GetNearbyRestaurantsQueryHandler(RestaurantStore restaurantStore)
        {
            _restaurantStore = restaurantStore;
        }

        public async Task<IEnumerable<RestaurantModel>> Handle(GetNearbyRestaurantsQuery request, CancellationToken cancellationToken)
        {
            var currentLocation = new Point(request.Latitude, request.Longitude);

            return await _restaurantStore
                .GetQueryable(skipAuthorization: true)
                .Where(r => r.Location.Distance(currentLocation) < request.MaxDistance)
                .Select(r => new RestaurantModel
                {
                    Name = r.Name,
                    Description = r.Description,
                    Distance = r.Location.Distance(currentLocation)
                })
                .ToListAsync(cancellationToken);
        }
    }
}
