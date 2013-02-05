using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Foodle.Service.Model
{
    [DataContract]
    public class Restaurant
    {
        [Flags]
        public enum Weekdays
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 4,
            Thursday = 8,
            Friday = 16
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        [XmlIgnore]
        public string Url { get; set; }

        [DataMember]
        [XmlIgnore]
        public string Comment { get; set; }

        [DataMember]
        [XmlIgnore]
        public Weekdays Days { get; set; }
    }
}