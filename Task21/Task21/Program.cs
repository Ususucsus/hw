using System;

namespace Task21
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var testList = new List(new int[] { 1, 2, 3, 4, 5});
            Console.WriteLine(testList);
            Console.WriteLine($"{testList.GetValue(4)}, {testList.GetValue(0)}");
            testList.SetValue(0, 999);
            Console.WriteLine(testList);
            testList.Insert(0, 10);
            testList.Insert(0, 20);
            testList.Insert(7, 90);
            Console.WriteLine(testList);
            testList.Remove(0);
            testList.Remove(testList.Length() - 1);
            Console.WriteLine(testList);
            testList.Remove(1);
            Console.WriteLine(testList);
            Console.WriteLine(testList.IsEmpty());
            Console.WriteLine(new List(new int[] { }).IsEmpty());
        }
    }
}