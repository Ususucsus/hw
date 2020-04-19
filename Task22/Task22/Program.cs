using System;

namespace Task22
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var testHashTable = new HashTable(10);
            testHashTable.Insert("lolkek");
            Console.WriteLine(testHashTable.ContainsValue("lolkek"));
            Console.WriteLine(testHashTable.ContainsValue("keklol"));
            testHashTable.Remove("keklol");
            Console.WriteLine(testHashTable.ContainsValue("lolkek"));
            Console.WriteLine(testHashTable.ContainsValue("keklol"));
            testHashTable.Remove("lolkek");
            Console.WriteLine(testHashTable.ContainsValue("lolkek"));
            Console.WriteLine(testHashTable.ContainsValue("keklol"));
        }
    }
}
