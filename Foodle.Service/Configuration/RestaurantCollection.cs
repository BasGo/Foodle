using System.Configuration;

namespace Foodle.Service.Configuration
{
    [ConfigurationCollection(typeof(RestaurantElement), AddItemName = "Restaurant", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class RestaurantCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new RestaurantElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RestaurantElement)element).Name;
        }

        new public RestaurantElement this[string name]
        {
            get { return (RestaurantElement)BaseGet(name); }
        }
    }
}
