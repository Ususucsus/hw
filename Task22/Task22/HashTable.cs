// <copyright file="HashTable.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Task22
{
    using System;

    /// <summary>
    /// Represents a set of values. Provides methods to insert, remove and check for containing.
    /// </summary>
    public class HashTable
    {
        /// <summary>
        /// Maximum number of different hash codes.
        /// </summary>
        private readonly int size;

        /// <summary>
        /// Array to contain lists with same values with same hash codes.
        /// </summary>
        private readonly List[] array;

        /// <summary>
        /// Hash function for calculating hash.
        /// </summary>
        private readonly IHashFunction hashFunction;

        /// <summary>
        /// Initializes a new instance of the <see cref="HashTable"/> class.
        /// </summary>
        /// <param name="size">Maximum number of different hash codes.</param>
        /// <param name="hashFunction">Hash function object for calculating hash.</param>
        public HashTable(int size, IHashFunction hashFunction)
        {
            this.size = size;
            this.array = new List[size];

            for (var i = 0; i < size; ++i)
            {
                this.array[i] = new List(new string[] { });
            }

            this.hashFunction = hashFunction;
        }

        /// <summary>
        /// Inserts value to the hash table.
        /// </summary>
        /// <param name="value">Value to be inserted.</param>
        /// <exception cref="ArgumentException">Value already contains in hash table.</exception>
        public void Insert(string value)
        {
            if (this.ContainsValue(value))
            {
                throw new ArgumentException();
            }

            var hashValue = this.GetHash(value);

            this.array[hashValue].Insert(this.array[hashValue].Length(), value);
        }

        /// <summary>
        /// Checks if value contains in hash table.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>true if value contains in hash table, false otherwise.</returns>
        public bool ContainsValue(string value)
        {
            var hashValue = this.GetHash(value);

            for (var i = 0; i < this.array[hashValue].Length(); ++i)
            {
                if (this.array[hashValue].GetValue(i) == value)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes value from hash table.
        /// </summary>
        /// <param name="value">Value to be removed.</param>
        public void Remove(string value)
        {
            var hashValue = this.GetHash(value);

            for (var i = 0; i < this.array[hashValue].Length(); ++i)
            {
                if (this.array[hashValue].GetValue(i) == value)
                {
                    this.array[hashValue].Remove(i);
                    return;
                }
            }
        }

        /// <summary>
        /// Returns hash code of value within limits.
        /// </summary>
        /// <param name="value">Value form which hash will be calculated.</param>
        /// <returns>Hash within limits.</returns>
        private int GetHash(string value)
            => Math.Abs(this.hashFunction.GetHashValue(value)) % this.size;
    }
}
