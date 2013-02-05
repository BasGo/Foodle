using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Foodle.Service.Contracts
{
    public enum ResponseStatus
    {
        Unknown = -1,
        Update = 0,
        Inserted = 1
    }

    [DataContract]
    public class SaveVoteResponse
    {
        [DataMember]
        public ResponseStatus Status { get; set; }
    }
}