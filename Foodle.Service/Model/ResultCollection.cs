using System.Collections.Generic;
using System.Linq;
using Foodle.Service.Contracts;

namespace Foodle.Service.Model
{
    public class ResultCollection
    {
        private Dictionary<string, int> _items;

        private Dictionary<string, int> OrderedEntries
        {
            get
            {
                return _items.OrderByDescending(t => t.Value).ToDictionary(x => x.Key, x => x.Value);
            }
        }

        public void Add(Restaurant restaurant, int points)
        {
            if (_items == null)
                _items = new Dictionary<string, int>();

            if (!_items.ContainsKey(restaurant.Name))
                _items.Add(restaurant.Name, 0);

            _items[restaurant.Name] += points;
        }

        public ResultItem GetResult(int position)
        {
            var entry = OrderedEntries.ElementAtOrDefault(position - 1);
            return new ResultItem
                {
                    Name = entry.Key,
                    Points = entry.Value,
                    Users = new List<string>()
                };
        }

    }
}