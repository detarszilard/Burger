using Burger.Services.Restaurants.Domain.Aggregates.ReviewAggregate;
using MediatR;

namespace Burger.Services.Restaurants.Domain.Events
{
    public class ReviewCreatedDomainEvent : INotification
    {
        public Review Entity { get; }

        public ReviewCreatedDomainEvent(Review entity)
        {
            Entity = entity;
        }
    }
}
