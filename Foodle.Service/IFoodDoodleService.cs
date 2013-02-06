using System.ServiceModel;
using Foodle.Service.Contracts;
using Foodle.Service.Model;

namespace Foodle.Service
{
    [ServiceContract]
    public interface IFoodleService
    {
        [OperationContract]
        GetVoteOptionsResponse GetVoteOptions();

        [OperationContract]
        SaveVoteResponse SubmitVote(SaveVoteRequest request);

        [OperationContract]
        GetResultsResponse GetResults();
    }
}
