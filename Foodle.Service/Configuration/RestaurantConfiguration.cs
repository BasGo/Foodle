using System.Configuration;

namespace Foodle.Service.Configuration
{
    public class RestaurantConfiguration : ConfigurationSection
    {
        private static readonly ConfigurationProperty DeadlineAttribute = new ConfigurationProperty("Deadline", typeof(string), "12:00", ConfigurationPropertyOptions.IsRequired);

        private static readonly ConfigurationProperty RestaurantsElement = new ConfigurationProperty("Restaurants", typeof(RestaurantCollection), null, ConfigurationPropertyOptions.IsRequired);

        public RestaurantConfiguration()
        {
            base.Properties.Add(DeadlineAttribute);
            base.Properties.Add(RestaurantsElement);
        }

        [ConfigurationProperty("Deadline", IsRequired = true)]
        public string Deadline
        {
            get { return (string)this[DeadlineAttribute]; }
        }
        
        [ConfigurationProperty("Restaurants", IsRequired = true)]
        public RestaurantCollection Restaurants
        {
            get { return (RestaurantCollection)this[RestaurantsElement]; }
        }
    }
}
