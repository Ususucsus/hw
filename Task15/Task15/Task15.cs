using System;

namespace Task15
{
    class Task15
    {
        private static void SortColumns(int[,] array)
        {
            for (var i = 0; i < array.GetLength(1); ++i)
            {
                for (var j = 1; j < array.GetLength(1) - i; ++j)
                {
                    if (array[0, j - 1] > array[0, j])
                    {
                        SwapColumns(array, j - 1, j);
                    }
                }
            }
        }

        private static void SwapColumns(int[,] array, int column1, int column2)
        {
            for (var i = 0; i < array.GetLength(0); ++i)
            {
                var t = array[i, column1];
                array[i, column1] = array[i, column2];
                array[i, column2] = t;
            }
        }

        private static void PrintArray(int[,] array)
        {
            for (var i = 0; i < array.GetLength(0); ++i)
            {
                for (var j = 0; j < array.GetLength(1); ++j)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void Main(string[] args)
        {
            var testArray = new int[4, 7];
            var random = new Random();

            for (var i = 0; i < 4; ++i)
            {
                for (var j = 0; j < 7; ++j)
                {
                    testArray[i, j] = random.Next(28);
                }
            }

            PrintArray(testArray);

            SortColumns(testArray);

            PrintArray(testArray);
        }
    }
}
