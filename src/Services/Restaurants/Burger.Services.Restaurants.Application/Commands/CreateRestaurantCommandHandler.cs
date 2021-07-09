using System.Threading;
using System.Threading.Tasks;
using Burger.Common.EntityFrameworkCore.Stores;
using Burger.Services.Restaurants.Domain.Aggregates.RestaurantAggregate;
using MediatR;
using NetTopologySuite.Geometries;

namespace Burger.Services.Restaurants.Application.Commands
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand>
    {
        private readonly IEntityStore<Restaurant> _restaurantStore;

        public CreateRestaurantCommandHandler(IEntityStore<Restaurant> restaurantStore)
        {
            _restaurantStore = restaurantStore;
        }

        public async Task<Unit> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            _restaurantStore.Add(new Restaurant(
                request.Name,
                request.Description,
                new Point(request.Latitude, request.Longitude)));

            await _restaurantStore.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
