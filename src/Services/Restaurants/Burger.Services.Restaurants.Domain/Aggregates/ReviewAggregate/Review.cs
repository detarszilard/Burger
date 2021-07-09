using Burger.Common.SeedWork;
using Burger.Services.Restaurants.Domain.Events;

namespace Burger.Services.Restaurants.Domain.Aggregates.ReviewAggregate
{
    public class Review : Entity
    {
        private string _userId;
        private string _menuItemId;
        private Score _score;
        private string? _description;
        private string? _pictureUrl;

        public string UserId => _userId;

        public string MenuItemId => _menuItemId;

        public Score Score => _score;

        public string? Description => _description;

        public string? PictureUrl => _pictureUrl;

        protected Review() { }

        public Review(string userId, string menuItemId, Score score, string? description = null, string? pictureUrl = null)
        {
            _userId = userId;
            _menuItemId = menuItemId;
            _score = score;
            _description = description;
            _pictureUrl = pictureUrl;

            AddDomainEvent(new ReviewCreatedDomainEvent(this));
        }
    }
}
