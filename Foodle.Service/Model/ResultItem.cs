using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Foodle.Service.Model
{
    public class ResultItem
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Points { get; set; }

        [DataMember]
        public List<string> Users { get; set; }
    }
}