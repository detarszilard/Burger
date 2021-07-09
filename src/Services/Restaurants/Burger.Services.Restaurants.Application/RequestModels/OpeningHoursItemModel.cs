using System;

namespace Burger.Services.Restaurants.Application.RequestModels
{
    public class OpeningHoursItemModel
    {
        public DayOfWeek Day { get; set; }

        public int OpeningHour { get; set; }

        public int OpeningMinute { get; set; }

        public int ClosingHour { get; set; }

        public int ClosingMinute { get; set; }
    }
}
