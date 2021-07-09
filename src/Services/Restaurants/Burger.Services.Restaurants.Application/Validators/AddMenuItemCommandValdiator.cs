using Burger.Services.Restaurants.Application.Commands;
using FluentValidation;

namespace Burger.Services.Restaurants.Application.Validators
{
    public class AddMenuItemCommandValdiator : AbstractValidator<AddMenuItemCommand>
    {
        public AddMenuItemCommandValdiator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.RestaurantId).NotEmpty();
            RuleFor(c => c.PictureUrl).NotEmpty();
        }
    }
}
