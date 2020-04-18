using System;

namespace Task22
{
    /// <summary>
    /// Represents a set of values. Provides methods to insert, remove and check for containing.
    /// </summary>
    public class HashTable
    {
        /// <summary>
        /// Initializes a new instance of <see cref="HashTable"/> class.
        /// </summary>
        /// <param name="size">Maximum number of different hash codes</param>
        public HashTable(int size)
        {
            this.size = size;
            array = new List[size];

            for (var i = 0; i < size; ++i) 
                array[i] = new List(new string[] { } );
        }

        /// <summary>
        /// Inserts value to the hash table.
        /// </summary>
        /// <param name="value">Value to be inserted</param>
        /// <exception cref="ArgumentException">Value already contains in hash table</exception>
        public void Insert(string value)
        {
            if (this.ContainsValue(value))
                throw new ArgumentException();

            var hashValue = GetHash(value);

            array[hashValue].Insert(array[hashValue].Length(), value);
        }

        /// <summary>
        /// Checks if value contains in hash table
        /// </summary>
        /// <param name="value">Value to be checked</param>
        /// <returns>true if value contains in hash table, false otherwise</returns>
        public bool ContainsValue(string value)
        {
            var hashValue = GetHash(value);

            for (var i = 0; i < array[hashValue].Length(); ++i)
            {
                if (array[hashValue].GetValue(i) == value)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Removes value from hash table
        /// </summary>
        /// <param name="value">Value to be removed</param>
        public void Remove(string value)
        {
            var hashValue = GetHash(value);

            for (var i = 0; i < array[hashValue].Length(); ++i)
            {
                if (array[hashValue].GetValue(i) == value)
                {
                    array[hashValue].Remove(i);
                    return;
                }
            }
        }

        /// <summary>
        /// Returns hash code of value within limits.
        /// </summary>
        /// <param name="value">Value form which hash will be calculated</param>
        /// <returns>Hash within limits</returns>
        private int GetHash(string value)
            => Math.Abs(value.GetHashCode()) % size;

        /// <summary>
        /// Maximum number of different hash codes.
        /// </summary>
        private readonly int size;

        /// <summary>
        /// Array to contain lists with same values with same hash codes.
        /// </summary>
        private readonly List[] array;
    }
}
