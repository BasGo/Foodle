using System.ServiceModel;
using Foodle.Service.Contracts;
using Foodle.Service.Model;

namespace Foodle.Service
{
    [ServiceContract]
    public interface IFoodleService
    {
        [OperationContract]
        Options GetVoteOptions();

        [OperationContract]
        SaveVoteResponse SubmitVote(SaveVoteRequest request);

        [OperationContract]
        Results GetResults();
    }
}
