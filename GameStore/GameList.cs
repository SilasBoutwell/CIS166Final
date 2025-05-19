using System;
using System.Collections.Generic;
using System.Linq;

namespace GameStore
{
    /// <summary>
    /// This is a list that can hold any type of item.
    /// </summary>
    /// <typeparam name="T">Type of items in the list</typeparam>
    public class ItemList<T>
    {
        private List<T> items;

        public ItemList()
        {
            items = new List<T>();
        }

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public void RemoveItem(T item)
        {
            items.Remove(item);
        }

        public List<T> GetAllItems()
        {
            return items;
        }

        public List<T> FilterItems(IFilter<T> filter)
        {
            if (filter == null)
                return new List<T>(items);

            return items.Where(item => filter.IsMatch(item)).ToList();
        }
    }
}
