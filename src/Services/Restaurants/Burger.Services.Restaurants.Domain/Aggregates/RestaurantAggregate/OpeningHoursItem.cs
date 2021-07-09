using System;
using Burger.Common.Exceptions;
using Burger.Common.SeedWork;
using Burger.Services.Restaurants.Domain.Constants;

namespace Burger.Services.Restaurants.Domain.Aggregates.RestaurantAggregate
{
    public class OpeningHoursItem : Entity
    {
        private DayOfWeek _day;
        private Time _openingTime;
        private Time _closingTime;

        public DayOfWeek Day => _day;

        public Time OpeningTime => _openingTime;

        public Time ClosingTime => _closingTime;

        protected OpeningHoursItem() { }

        public OpeningHoursItem(DayOfWeek dayOfWeek, Time openingTime, Time closingTime)
        {
            if (closingTime <= openingTime)
            {
                throw new DomainException(RestaurantErrorCodes.ClosingTimeIsLessThanOrEqualToOpeningTime);
            }

            _day = dayOfWeek;
            _openingTime = openingTime;
            _closingTime = closingTime;
        }
    }
}
