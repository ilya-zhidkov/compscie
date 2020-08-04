using System;
using System.Collections.Generic;

namespace CompScie.Core
{
    /// <summary>
    /// Represents a key-value pair data structure. Solves potential collisions using closed addressing technique.
    /// Instead of storing hash codes in an array they are stored in a linked list.
    /// </summary>
    /// <remarks>
    /// Most of operations perform in O(1) time complexity because of the hash function.
    /// To proof the concept, the maximum size is set to 5.
    /// </remarks>
    public class HashTable
    {
        /// <summary>
        /// Represents an encapsulation over a key-value pair.
        /// </summary>
        /// <remarks>Semantically similar to a <see cref="LinkedList{T}.Node"/>.</remarks>
        public class Entry
        {
            /// <summary>
            /// Stores a numerical representation of the appropriate placement of a value in memory.
            /// </summary>
            public int Key { get; private set; }

            /// <summary>
            /// A textual value to store.
            /// </summary>
            public string Value { get; set; }

            /// <summary>
            /// Constructs a new instance of <see cref="Entry"/>.
            /// </summary>
            /// <param name="key">Stores a numerical representation of the appropriate placement of a value in memory.</param>
            /// <param name="value">A textual value to store.</param>
            public Entry(int key, string value)
            {
                Key = key;
                Value = value;
            }

            /// <summary>
            /// Overrides the default behavior of the parent <see cref="String"/> class.
            /// </summary>
            /// <returns>Key=Value string representation.</returns>
            public override string ToString() => $"{Key}={Value}";
        }

        /// <summary>
        /// An array of linked lists used for the resolution of potential collisions.
        /// </summary>
        /// <remarks>Initial size is set to 5.</remarks>
        private readonly LinkedList<Entry>[] entries = new LinkedList<Entry>[5];

        /// <summary>
        /// Keeps track of how many non-null items are presented in the <see cref="HashTable"/>.
        /// </summary>
        /// <remarks>Time complexity: O(1).</remarks>
        public int Count { get; private set; }

        /// <summary>
        /// Adds a textual value to the <see cref="HashTable"/>.
        /// </summary>
        /// <remarks>Time complexity: O(1).</remarks>
        public void Put(int key, string value)
        {
            // Find the entry with that key.
            var entry = GetEntry(key);

            // If this node exists...
            if (entry != null)
            {
                // set it's value appropriately.
                entry.Value = value;

                // Stop the execution.
                return;
            }

            // Append a new entry at the end of the list.
            GetOrCreateBucket(key).AddLast(new Entry(key, value));

            // Increase the amount of entries in the hash table. 
            Count++;
        }

        /// <summary>
        /// Retrieves a value from <see cref="HashTable"/> based on the passed in key.
        /// </summary>
        /// <param name="key">A lookup needle.</param>
        /// <remarks>Time complexity: O(1).</remarks>
        /// <returns>A value of the <see cref="HashTable"/> entry.</returns>
        public string Get(int key) => GetEntry(key)?.Value;

        /// <summary>
        /// Removes an entry from the <see cref="HashTable"/> based on the passed in key.
        /// </summary>
        /// <param name="key">A lookup needle.</param>
        /// <remarks>Time complexity: O(1).</remarks>
        public void Remove(int key)
        {
            // Find the entry with that key.
            var entry = GetEntry(key);

            // If this entry wasn't found...
            if (entry == null)
            {
                // raise an exception saying that this entry wasn't found.
                throw new InvalidOperationException($"An entry with that key was not found.");
            }

            // Otherwise; remove this entry.
            GetBucket(key).Remove(entry);

            // Decrease the amount of entries in the hash table.
            Count--;
        }

        /// <summary>
        /// Overrides the default behavior of the parent <see cref="String"/> class.
        /// </summary>
        /// <example>
        /// <code>
        /// var table = new HashTable();
        /// table.Put(6, "a");
        /// table.Put(8, "b");
        /// table.Put(11, "c");
        /// Console.WriteLine(table); // {6=a, 11=c, 8=b}
        /// </code>
        /// </example>
        /// <returns>A string representation of the entries of the <see cref="HashTable"/> enclosed in curly braces.</returns>
        public override string ToString()
        {
            // A result list that contains key-value pairs (if any).
            var pairs = new List<string>();

            // Iterate over all entries in the hash table...
            for (var index = 0; index < entries.Length; index++)
            {
                // knowing that those entries are made of linked lists
                // start traversing the list from the head node...
                var current = entries[index]?.Head;

                // until we reach end...
                while (current != null)
                {
                    // add key-value pair to the result output.
                    pairs.Add($"{current.Data.Key}={current.Data.Value}");

                    // Move on to the next entry (eg. node).
                    current = current.Next;
                }
            }

            // Finally, return enclosed key-value pairs in a pair of curly braces.
            return $"{{{string.Join(", ", pairs)}}}";
        }

        /// <summary>
        /// Gets an existing "bucket" based on the provided key. Otherwise; creates a new bucket.
        /// </summary>
        /// <param name="key">A lookup needle.</param>
        /// <returns>A <see cref="LinkedList{T}"/> based on the provided key.</returns>
        private LinkedList<Entry> GetOrCreateBucket(int key)
        {
            // Get the hash code / index from the input key.
            var index = Hash(key);

            // Find the "bucket" (eg. linked list) in the hash table.
            var bucket = entries[index];

            // If there is no bucket with that key...
            if (bucket == null)
            {
                // create a new one.
                entries[index] = new LinkedList<Entry>();
            }

            // Return an existing or a new linked list.
            return bucket ?? entries[index];
        }

        /// <summary>
        /// Find the bucket (eg. linked list) based on the provided key.
        /// </summary>
        /// <param name="key">A lookup needle.</param>
        /// <returns>A <see cref="LinkedList{T}"/> based on the provided key.</returns>
        private LinkedList<Entry> GetBucket(int key) => entries[Hash(key)];

        /// <summary>
        /// Find the linked list entry (node) based on the provided key.
        /// </summary>
        /// <param name="key">A lookup needle.</param>
        /// <returns>An <see cref="Entry"/> based on the provided key.</returns>
        private Entry GetEntry(int key)
        {
            // Find the "bucket" (eg. linked list) in the hash table.
            var bucket = GetBucket(key);

            // If we have this cell (eg. bucket)...
            if (bucket != null)
            {
                // Iterate over all entries in the list...
                foreach (var entry in bucket)
                {
                    // if keys match...
                    if (entry.Key == key)
                    {
                        // return this entry immediately.
                        return entry;
                    }
                }
            }

            // If we couldn't find the entry (node) with that key - return null.
            return null;

        }

        /// <summary>
        /// Generates a hash code based on the provided key.
        /// </summary>
        /// <param name="key">A unique (ideally) identifier of an entity.</param>
        /// <returns>A hash code which determines the appropriate place in a <see cref="HashTable"/>.</returns>
        private int Hash(int key) => key % entries.Length;
    }
}
