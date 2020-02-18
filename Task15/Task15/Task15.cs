using System;

namespace Task15
{
    class Task15
    {
        private static void SortColumns(int[,] arrInts)
        {
            for (var i = 0; i < arrInts.GetLength(1); ++i)
            {
                for (var j = 1; j < arrInts.GetLength(1) - i; ++j)
                {
                    if (arrInts[0, j - 1] > arrInts[0, j])
                    {
                        SwapColumns(arrInts, j - 1, j);
                    }
                }
            }
        }

        private static void SwapColumns(int[,] arrInts, int column1, int column2)
        {
            for (var i = 0; i < arrInts.GetLength(0); ++i)
            {
                var t = arrInts[i, column1];
                arrInts[i, column1] = arrInts[i, column2];
                arrInts[i, column2] = t;
            }
        }

        static void Main(string[] args)
        {
            var testArray = new int[4, 7];
            var random = new Random();

            for (var i = 0; i < 4; ++i)
            {
                for (var j = 0; j < 7; ++j)
                {
                    testArray[i, j] = random.Next(28);
                    Console.Write($"{testArray[i, j]} ");
                }
                Console.WriteLine();
            }

            SortColumns(testArray);

            Console.WriteLine("Sorted:");
            for (var i = 0; i < 4; ++i)
            {
                for (var j = 0; j < 7; ++j)
                {
                    Console.Write($"{testArray[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
