using System.Collections.Generic;
using Burger.Common.SeedWork;
using NetTopologySuite.Geometries;

namespace Burger.Services.Restaurants.Domain.Aggregates.RestaurantAggregate
{
    public class Restaurant : Entity
    {
        private string _name;
        private string _description;
        private Point _location;
        private List<MenuItem> _menu = new List<MenuItem>();
        private List<OpeningHoursItem> _openingHours = new List<OpeningHoursItem>();

        public string Name => _name;

        public string Description => _description;

        public Point Location => _location;

        public IReadOnlyCollection<MenuItem> Menu => _menu;

        public IReadOnlyCollection<OpeningHoursItem> OpeningHours => _openingHours;

        public Restaurant(string name, string description, Point location)
        {
            // TODO: Validation

            _name = name;
            _description = description;
            _location = location;
        }

        public void AddMenuItem(MenuItem item)
        {
            _menu.Add(item);
        }

        public void SetOpeningHours(List<OpeningHoursItem> openingHours)
        {
            // TODO: Validation

            _openingHours.Clear();
            _openingHours.AddRange(openingHours);
        }
    }
}
