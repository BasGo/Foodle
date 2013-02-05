using System;

namespace Foodle.Service
{
    public class Helper
    {
        public static DateTime GetDeadline(string value)
        {
            var timeparts = value.Split(new[] { ':' });
            var now = DateTime.Now;
            var result = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 30, 0);

            if (timeparts.Length == 2)
                result = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt16(timeparts[0]), Convert.ToInt16(timeparts[1]), 0);

            if (result < now)
                result = result.AddDays(1);

            return result;

        }
    }
}