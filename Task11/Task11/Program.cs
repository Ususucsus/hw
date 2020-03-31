using System;

namespace Task11
{
    class Program
    {
        private static int Factorial(int n)
            => n <= 1 ? 1 : n * Factorial(n - 1);

        static void Main(string[] args)
        {
            Console.WriteLine($"Factorial(5): {Factorial(5)}");
        }
    }
}
