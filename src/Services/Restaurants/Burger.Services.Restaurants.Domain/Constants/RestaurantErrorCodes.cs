namespace Burger.Services.Restaurants.Domain.Constants
{
    public class RestaurantErrorCodes
    {
        private const string _prefix = "restaurant_";

        public const string ClosingTimeIsLessThanOrEqualToOpeningTime = _prefix + "closing_time_is_less_than_or_equal_to_opening_time";
    }
}
