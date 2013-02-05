using System.ServiceModel;
using Foodle.Service.Model;

namespace Foodle.Service
{
    [ServiceContract]
    public interface IFoodleService
    {
        [OperationContract]
        VoteOptions GetVoteOptions();

        [OperationContract]
        bool SubmitVote(Vote vote);

        [OperationContract]
        bool GetResults();
    }
}
