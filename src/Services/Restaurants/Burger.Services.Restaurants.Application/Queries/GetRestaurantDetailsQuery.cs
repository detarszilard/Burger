using Burger.Services.Restaurants.Application.ResponseModels;
using MediatR;

namespace Burger.Services.Restaurants.Application.Queries
{
    public class GetRestaurantDetailsQuery : IRequest<RestaurantDetailsModel>
    {
        public string RestaurantId { get; }

        public GetRestaurantDetailsQuery(string restaurantId)
        {
            RestaurantId = restaurantId;
        }
    }
}
