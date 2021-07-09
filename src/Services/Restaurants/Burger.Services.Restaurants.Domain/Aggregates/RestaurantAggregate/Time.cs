using System;
using System.Collections.Generic;
using Burger.Common.SeedWork;

namespace Burger.Services.Restaurants.Domain.Aggregates.RestaurantAggregate
{
    public class Time : ValueObject, IComparable<Time>
    {
        private int _hour;
        private int _minute;

        public int Hour => _hour;

        public int Minute => _minute;

        protected Time() { }

        public Time(int hour, int minute)
        {
            // TODO: Validate hour and minute
            _hour = hour;
            _minute = minute;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _hour;
            yield return _minute;
        }

        public int CompareTo(Time other)
        {
            int convertToMinitues(Time time) => (time.Hour * 60) + time.Minute;

            return convertToMinitues(this) - convertToMinitues(other);
        }

        public static bool operator <(Time left, Time right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Time left, Time right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Time left, Time right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Time left, Time right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
