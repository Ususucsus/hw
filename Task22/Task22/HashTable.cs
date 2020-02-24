using System;

namespace Task22
{
    internal class HashTable
    {
        public HashTable(int size)
        {
            this.size = size;
            array = new List[size];

            for (var i = 0; i < size; ++i) 
                array[i] = new List(new string[] { } );
        }

        public void Insert(string value)
        {
            if (this.ContainsValue(value))
                throw new ArgumentException();

            var hashValue = GetHash(value);

            array[hashValue].Insert(array[hashValue].Length(), value);
        }

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

        private int GetHash(string value)
            => Math.Abs(value.GetHashCode()) % size;

        private readonly int size;
        private readonly List[] array;
    }
}
