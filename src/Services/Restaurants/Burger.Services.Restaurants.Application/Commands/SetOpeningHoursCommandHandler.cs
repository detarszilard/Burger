using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Burger.Common.EntityFrameworkCore.Stores;
using Burger.Services.Restaurants.Domain.Aggregates.RestaurantAggregate;
using MediatR;

namespace Burger.Services.Restaurants.Application.Commands
{
    public class SetOpeningHoursCommandHandler : IRequestHandler<SetOpeningHoursCommand>
    {
        private readonly IEntityStore<Restaurant> _restaurantStore;

        public SetOpeningHoursCommandHandler(IEntityStore<Restaurant> restaurantStore)
        {
            _restaurantStore = restaurantStore;
        }

        public async Task<Unit> Handle(SetOpeningHoursCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantStore.GetEntityAsync(request.RestaurantId, cancellationToken);

            restaurant.SetOpeningHours(request.OpeningHours
                .Select(o => new OpeningHoursItem(o.Day, new Time(o.OpeningHour, o.OpeningMinute), new Time(o.ClosingHour, o.ClosingMinute)))
                .ToList());

            await _restaurantStore.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
