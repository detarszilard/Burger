using Burger.Common.Events;
using MediatR;

namespace Burger.Services.Restaurants.Application.Commands
{
    public class AddReviewCommand : IRequest, ICommand
    {
        public string MenuItemId { get; set; }

        public string? Description { get; set; }

        public string? PictureUrl { get; set; }

        public int Taste { get; set; }

        public int Texture { get; set; }

        public int VisualPresentation { get; set; }
    }
}
