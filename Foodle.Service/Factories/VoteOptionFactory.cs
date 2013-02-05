using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Foodle.Service.Configuration;
using Foodle.Service.Model;

namespace Foodle.Service.Factories
{
    public class VoteOptionFactory
    {
        public static VoteOptions CreateVoteOptions()
        {
            var tmp = (RestaurantConfiguration)ConfigurationManager.GetSection("RestaurantConfiguration");
            var deadline = Helper.GetDeadline(tmp.Deadline);
            Debug.WriteLine("Issued {0} to be the next deadline", deadline);

            var result = new VoteOptions { 
                Deadline = deadline, 
                Restaurants = new List<Restaurant>()
            };

            foreach (RestaurantElement re in tmp.Restaurants)
            {
                var rest = Mapper.Map(re);
                var deadlineWeekday = Helper.GetWeekday(deadline);
                var check = Helper.CheckWeekday(deadlineWeekday, rest.Days);
                if (check)
                {
                    result.Restaurants.Add(rest);
                    Debug.WriteLine("Added {0} to list of vote options (available: {1})", re.Name, re.Days);
                }
                else
                {
                    Debug.WriteLine("Skipped {0} from vote options (available: {1})", re.Name, re.Days);
                }

            }

            return result;
        }
    }
}