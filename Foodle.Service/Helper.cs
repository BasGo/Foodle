using System;
using System.Diagnostics;
using Foodle.Service.Model;

namespace Foodle.Service
{
    public class Helper
    {
        public static DateTime GetDeadline(string value)
        {
            var timeparts = value.Split(new[] { ':' });
            var next = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 30, 0);

            if (timeparts.Length == 2)
                next = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt16(timeparts[0]), Convert.ToInt16(timeparts[1]), 0);

            next = AddDays(next);

            return next;

        }

        private static DateTime AddDays(DateTime dateTime)
        {
            if (dateTime < DateTime.Now)
            {
                dateTime = dateTime.AddDays(1);
                Debug.WriteLine("Deadline already passed, added 1 day: {0}", dateTime);
                if (GetWeekday(dateTime) == DayOfWeek.Saturday)
                {
                    dateTime = dateTime.AddDays(2);
                    Debug.WriteLine("Deadline was saturday, added another 2 days: {0}", dateTime);
                }
            }

            return dateTime;
        }

        public static DayOfWeek GetWeekday(DateTime dateTime)
        {

            if (dateTime.DayOfWeek == DayOfWeek.Monday)
                return DayOfWeek.Monday;

            if (dateTime.DayOfWeek == DayOfWeek.Tuesday)
                return DayOfWeek.Tuesday;

            if (dateTime.DayOfWeek == DayOfWeek.Wednesday)
                return DayOfWeek.Wednesday;

            if (dateTime.DayOfWeek == DayOfWeek.Thursday)
                return DayOfWeek.Thursday;

            return DayOfWeek.Friday;
        }

        public static bool CheckWeekday(DayOfWeek deadline, DayOfWeek restaurant)
        {

            if ((restaurant & DayOfWeek.Monday) == deadline)
                return true;

            if ((restaurant & DayOfWeek.Tuesday) == deadline)
                return true;

            if ((restaurant & DayOfWeek.Wednesday) == deadline)
                return true;

            if ((restaurant & DayOfWeek.Thursday) == deadline)
                return true;

            if ((restaurant & DayOfWeek.Friday) == deadline)
                return true;

            return false;
        }
    }
}