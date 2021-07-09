using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Burger.Services.Restaurants.Application.ResponseModels;
using Burger.Services.Restaurants.Infrastructure.Stores;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Burger.Services.Restaurants.Application.Queries
{
    public class GetRestaurantDetailsQueryHandler : IRequestHandler<GetRestaurantDetailsQuery, RestaurantDetailsModel>
    {
        private readonly RestaurantStore _restaurantStore;

        public GetRestaurantDetailsQueryHandler(RestaurantStore restaurantStore)
        {
            _restaurantStore = restaurantStore;
        }

        public Task<RestaurantDetailsModel> Handle(GetRestaurantDetailsQuery request, CancellationToken cancellationToken)
        {
            return _restaurantStore
                .GetQueryable(skipAuthorization: true)
                .Where(r => r.Id == request.RestaurantId)
                .Select(r => new RestaurantDetailsModel
                {
                    Description = r.Description,
                    Name = r.Name,
                    Menu = r.Menu.Select(m => new MenuItemModel { Name = m.Name, Description = m.Description, PictureUrl = m.PictureUrl }),
                    OpeningHours = r.OpeningHours.Select(o => new OpeningHoursItemModel
                    {
                        Day = o.Day,
                        ClosingHour = o.ClosingTime.Hour,
                        ClosingMinute = o.ClosingTime.Minute,
                        OpeningHour = o.OpeningTime.Hour,
                        OpeningMinute = o.OpeningTime.Minute
                    })
                })
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
