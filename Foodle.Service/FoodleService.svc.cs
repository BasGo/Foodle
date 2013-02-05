using System.ServiceModel;
using System.ServiceModel.Activation;
using Foodle.Service.BL;
using Foodle.Service.Contracts;
using Foodle.Service.Factories;
using Foodle.Service.Model;

namespace Foodle.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FoodleService : IFoodleService
    {
        public Options GetVoteOptions()
        {
            var result = VoteOptionFactory.CreateVoteOptions();
            return result;
        }

        public SaveVoteResponse SubmitVote(SaveVoteRequest request)
        {
            var userName = OperationContext.Current.ServiceSecurityContext.WindowsIdentity.Name.Replace("ADESSO\\", "");
            var mapped = Mapper.Map(request.Vote, userName);
            return ResultsHandler.SaveVote(mapped);
        }

        public Results GetResults()
        {
            return ResultsHandler.GetResults();
        }
    }
}
