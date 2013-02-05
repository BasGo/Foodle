using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Foodle.Service.Contracts
{
    [DataContract]
    public class SaveVoteRequest
    {
        [DataMember]
        public Vote Vote { get; set; }
    }
}