using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Foodle.Service.Model
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
    }
}