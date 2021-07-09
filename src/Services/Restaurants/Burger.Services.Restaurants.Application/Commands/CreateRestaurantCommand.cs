using Burger.Common.Events;
using MediatR;

namespace Burger.Services.Restaurants.Application.Commands
{
    public class CreateRestaurantCommand : IRequest, ICommand
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
