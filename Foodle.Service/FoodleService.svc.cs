using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Foodle.Service.BL;
using Foodle.Service.Configuration;
using Foodle.Service.Model;

namespace Foodle.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FoodleService : IFoodleService
    {
        public VoteOptions GetVoteOptions()
        {

            var tmp = (RestaurantConfiguration)ConfigurationManager.GetSection("RestaurantConfiguration");
            var result = new VoteOptions { 
                Deadline = Helper.GetDeadline(tmp.Deadline), 
                Restaurants = new List<Restaurant>()
            };

            foreach (RestaurantElement re in tmp.Restaurants)
            {
                result.Restaurants.Add(Mapper.Map(re));
                Console.WriteLine("STOP");
            }

            return result;
        }

        public bool SubmitVote(Vote vote)
        {
            return ResultsHandler.SaveVote(
                new VoteResult
                    {
                        Date = DateTime.Now.ToString("yyyy-MM-dd"),
                        User = OperationContext.Current.ServiceSecurityContext.WindowsIdentity.Name.Replace("ADESSO\\", ""),
                        Prio1 = vote.Prio1,
                        Prio2 = vote.Prio2,
                        Prio3 = vote.Prio3
                    }
                );
        }

        public bool GetResults()
        {
            throw new NotImplementedException();
        }
    }
}
