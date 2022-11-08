using System.Collections.Generic;
using UnityEngine;

namespace Core.Modules.Utility
{
    public class Bucket<T>
    {
        List<T> itemSet;
        List<T> eligibleItems;

        public Bucket(List<T> providedItemSet)
        {
            itemSet = providedItemSet;
            
            // Making a copy
            eligibleItems = new List<T>();
            eligibleItems.AddRange(itemSet);
        }

        public T GetItem()
        {
            if (eligibleItems.Count == 0) Refresh();
            
            var random = Random.Range(0, eligibleItems.Count);
            var item = eligibleItems[random];

            eligibleItems.Remove(item);

            return item;
        }

        public void Refresh()
        {
            eligibleItems.Clear();
            eligibleItems.AddRange(itemSet);
        }
    }
}