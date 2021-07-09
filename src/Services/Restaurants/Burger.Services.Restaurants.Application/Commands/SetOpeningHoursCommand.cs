using System.Collections.Generic;
using Burger.Common.Events;
using Burger.Services.Restaurants.Application.RequestModels;
using MediatR;

namespace Burger.Services.Restaurants.Application.Commands
{
    public class SetOpeningHoursCommand : IRequest, ICommand
    {
        public string RestaurantId { get; set; }

        public IEnumerable<OpeningHoursItemModel> OpeningHours { get; set; }
    }
}
