using System.Collections.Generic;
using Burger.Services.Restaurants.Application.ResponseModels;
using MediatR;

namespace Burger.Services.Restaurants.Application.Queries
{
    public class GetNearbyRestaurantsQuery : IRequest<IEnumerable<RestaurantModel>>
    {
        public double Latitude { get; }

        public double Longitude { get; }

        public double MaxDistance { get; }

        public GetNearbyRestaurantsQuery(double latitude, double longitude, double maxDistance)
        {
            Latitude = latitude;
            Longitude = longitude;
            MaxDistance = maxDistance;
        }
    }
}
