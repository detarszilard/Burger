using Burger.Common.SeedWork;

namespace Burger.Services.Restaurants.Domain.Aggregates.RestaurantAggregate
{
    public class MenuItem : Entity
    {
        private string _name;
        private string _description;
        private string _pictureUrl;

        public string Name => _name;

        public string Description => _description;

        public string PictureUrl => _pictureUrl;

        protected MenuItem() { }

        public MenuItem(string name, string description, string pictureUrl)
        {
            // TODO: Validation

            _name = name;
            _description = description;
            _pictureUrl = pictureUrl;
        }
    }
}
