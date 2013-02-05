using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Foodle.Service.Contracts
{
    [DataContract]
    public class Options
    {
        [DataMember]
        public DateTime Deadline { get; set; }

        [DataMember]
        public List<Restaurant> Restaurants { get; set; }
    }
}
