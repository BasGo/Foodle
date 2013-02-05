using System.Configuration;

namespace Foodle.Service.Configuration
{
    public class RestaurantElement : ConfigurationElement
    {
        private static readonly ConfigurationProperty NameAttribute = new ConfigurationProperty("Name", typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);

        private static readonly ConfigurationProperty DaysAttribute = new ConfigurationProperty("Days", typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);

        public RestaurantElement()
        {
            base.Properties.Add(NameAttribute);
            base.Properties.Add(DaysAttribute);
        }

        [ConfigurationProperty("Name", IsRequired = true)]
        public string Name
        {
            get { return (string)this[NameAttribute]; }
        }

        [ConfigurationProperty("Days", IsRequired = true)]
        public string Days
        {
            get { return (string)this[DaysAttribute]; }
        }
    }
}
