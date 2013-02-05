using System;
using System.Globalization;
using Foodle.Service.Configuration;
using Foodle.Service.Model;

namespace Foodle.Service
{
    public class Mapper
    {
        public static Restaurant Map(RestaurantElement restaurant)
        {
            var result = new Restaurant
                {
                    Name = restaurant.Name,
                    Days = (Restaurant.Weekdays) Enum.Parse(typeof (Restaurant.Weekdays), GetWeekdayEnum(restaurant.Days))
                };
            return result;
        }

        private static string GetWeekdayEnum(string value)
        {
            var days = value.Split(new[] { ',', '|' });
            var result = 0;

            foreach (var day in days)
            {
                switch (day.ToLower())
                {
                    case "monday":
                        result += 1;
                        break;
                    case "tuesday":
                        result += 2;
                        break;
                    case "wednesday":
                        result += 4;
                        break;
                    case "thursday":
                        result += 8;
                        break;
                    case "friday":
                        result += 16;
                        break;
                }
            }
            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}