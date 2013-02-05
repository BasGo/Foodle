using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Foodle.Service.Model
{
    [DataContract]
    public class VoteOptions
    {
        [DataMember]
        public DateTime Deadline { get; set; }

        [DataMember]
        public List<Restaurant> Restaurants { get; set; }
    }
}
