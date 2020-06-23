using System;
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

        public bool ContainsKey(int key) => BinarySearch(key) >= 0;

        private int BinarySearch(int key) => BinarySearch(items, key, 0, items.Length - 1);

        private int BinarySearch(int[] array, int key, int left, int right)
        {
            if (right < left)
                return -1;

            var middle = (left + right) / 2;

            if (array[middle] == key)
                return middle;

            if (key < array[middle])
                return BinarySearch(array, key, left, middle - 1);

            return BinarySearch(array, key, middle + 1, right);
        }

        private int LinearSearch(int key)
        {
            for (var index = 0; index < items.Length; index++)
                if (items[index] == key)
                    return index;

            return -1;
        }
    }
}
