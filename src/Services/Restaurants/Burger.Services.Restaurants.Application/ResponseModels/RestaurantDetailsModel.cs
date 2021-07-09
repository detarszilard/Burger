using System;
using System.Collections.Generic;

namespace Burger.Services.Restaurants.Application.ResponseModels
{
    public class RestaurantDetailsModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<MenuItemModel> Menu { get; set; }

        public IEnumerable<OpeningHoursItemModel> OpeningHours { get; set; }
    }

    public class MenuItemModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }
    }

    public class OpeningHoursItemModel
    {
        public DayOfWeek Day { get; set; }

        public int OpeningHour { get; set; }

        public int OpeningMinute { get; set; }

        public int ClosingHour { get; set; }

        public int ClosingMinute { get; set; }
    }
}
