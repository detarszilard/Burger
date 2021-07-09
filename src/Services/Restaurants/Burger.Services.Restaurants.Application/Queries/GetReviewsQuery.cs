using System.Collections.Generic;
using Burger.Services.Restaurants.Application.ResponseModels;
using MediatR;

namespace Burger.Services.Restaurants.Application.Queries
{
    public class GetReviewsQuery : IRequest<IEnumerable<ReviewModel>>
    {
        public string MenuItemId { get; }

        public GetReviewsQuery(string menuItemId)
        {
            MenuItemId = menuItemId;
        }
    }
}
