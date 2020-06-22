using System.Collections.Generic;

namespace CompScie.Core
{
    public class Search
    {
        private readonly int[] items;

        public Search(int[] array) => items = array;

        public int Lookup(int key)
        {
            var frequency = new Dictionary<int, int>();

            if (!ContainsKey(key))
                return default;

            foreach (var item in items)
            {
                if (frequency.ContainsKey(item))
                    frequency[item]++;
                else
                    frequency[item] = 1;
            }

            return frequency[key];
        }

        public bool ContainsKey(int key) => LinearSearch(key) >= 0;

        private int LinearSearch(int key)
        {
            for (var index = 0; index < items.Length; index++)
                if (items[index] == key)
                    return index;

            return -1;
        }
    }
}
