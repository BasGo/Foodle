using System.Runtime.Serialization;
using Foodle.Service.Model;

namespace Foodle.Service.Contracts
{
    [DataContract]
    public class GetResultsResponse
    {
        [DataMember]
        public Results Results { get; set; }
    }
}