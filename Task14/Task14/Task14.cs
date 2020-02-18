using System;

namespace Task14
{
    class Task14
    {
        private enum Direction
        {
            Right = 0,
            Up = 1,
            Left = 2,
            Down = 3
        }

        private static void PrintSpiral(int[,] arrInts)
        {
            int[] dx = {1, 0, -1, 0};
            int[] dy = {0, -1, 0, 1};
            var size = arrInts.GetLength(0);
            var currentDirection = Direction.Right;
            var x = size / 2;
            var y = size / 2;

            for (var i = 0; i < arrInts.Length; ++i)
            {
                Console.Write($"{arrInts[y, x]} ");

                if ((x == y && y < size / 2) || (y + 1 == x && y >= size / 2) || (size - 1 - y == x && x != y))
                {
                    switch (currentDirection)
                    {
                        case Direction.Right:
                        case Direction.Up:
                        case Direction.Left:
                            currentDirection++;
                            break;
                        case Direction.Down:
                            currentDirection = 0;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                x += dx[(int) currentDirection];
                y += dy[(int) currentDirection];
            }

        }

        static void Main(string[] args)
        {
            var testArray = new int[5, 5];
            var random = new Random();

            for (var i = 0; i < 5; ++i)
            {
                for (var j = 0; j < 5; ++j)
                {
                    testArray[i, j] = random.Next(100);
                    Console.Write($"{testArray[i, j]} ");
                }
                Console.WriteLine();
            }

            PrintSpiral(testArray);
        }
    }
}
