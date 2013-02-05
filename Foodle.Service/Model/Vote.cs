using System.Runtime.Serialization;

namespace Foodle.Service.Model
{
    [DataContract]
    public class Vote
    {
        [DataMember]
        public Restaurant Prio1 { get; set; }

        [DataMember]
        public Restaurant Prio2 { get; set; }

        [DataMember]
        public Restaurant Prio3 { get; set; }
    }
}