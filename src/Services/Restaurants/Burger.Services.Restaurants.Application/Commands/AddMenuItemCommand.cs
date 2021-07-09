using Burger.Common.Events;
using MediatR;

namespace Burger.Services.Restaurants.Application.Commands
{
    public class AddMenuItemCommand : IRequest, ICommand
    {
        public string RestaurantId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }
    }
}
