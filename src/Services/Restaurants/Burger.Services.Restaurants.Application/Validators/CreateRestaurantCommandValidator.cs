using Burger.Services.Restaurants.Application.Commands;
using FluentValidation;

namespace Burger.Services.Restaurants.Application.Validators
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Latitude).GreaterThan(-90).LessThan(90);
            RuleFor(c => c.Longitude).GreaterThan(-180).LessThan(180);
        }
    }
}
