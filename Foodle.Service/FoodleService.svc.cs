using System.ServiceModel;
using System.ServiceModel.Activation;
using Foodle.Service.BL;
using Foodle.Service.Contracts;
using Foodle.Service.Factories;
using Foodle.Service.Model;

namespace Foodle.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class FoodleService : IFoodleService
    {
        public GetVoteOptionsResponse GetVoteOptions()
        {
            var options = VoteOptionFactory.CreateVoteOptions();
            return new GetVoteOptionsResponse {Options = options};
        }

        public SaveVoteResponse SubmitVote(SaveVoteRequest request)
        {
            var userName = OperationContext.Current.ServiceSecurityContext.WindowsIdentity.Name.Replace("ADESSO\\", "");
            var mapped = Mapper.Map(request.Vote, userName);
            return ResultsHandler.SaveVote(mapped);
        }

        public GetResultsResponse GetResults()
        {
            var results = ResultsHandler.GetResults();
            return new GetResultsResponse {Results = results};
        }
    }
}
