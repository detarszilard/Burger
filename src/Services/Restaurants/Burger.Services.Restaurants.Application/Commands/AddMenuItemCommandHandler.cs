using System.Threading;
using System.Threading.Tasks;
using Burger.Common.EntityFrameworkCore.Stores;
using Burger.Services.Restaurants.Domain.Aggregates.RestaurantAggregate;
using MediatR;

namespace Burger.Services.Restaurants.Application.Commands
{
    class AddMenuItemCommandHandler : IRequestHandler<AddMenuItemCommand>
    {
        private readonly IEntityStore<Restaurant> _restaurantStore;

        public AddMenuItemCommandHandler(IEntityStore<Restaurant> restaurantStore)
        {
            _restaurantStore = restaurantStore;
        }

        public async Task<Unit> Handle(AddMenuItemCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantStore.GetEntityAsync(request.RestaurantId, cancellationToken);

            restaurant.AddMenuItem(new MenuItem(request.Name, request.Description, request.PictureUrl));

            await _restaurantStore.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
