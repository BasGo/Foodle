using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Foodle.Service.Contracts
{
    [DataContract]
    public class Restaurant
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        [XmlIgnore]
        public string Url { get; set; }

        [DataMember]
        [XmlIgnore]
        public string Comment { get; set; }

        [XmlIgnore]
        public DayOfWeek Days { get; set; }

        [DataMember]
        public int VotePoints { get; set; }
    }
}