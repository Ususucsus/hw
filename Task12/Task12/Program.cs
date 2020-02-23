using System;

namespace Task12
{
    class Program
    {
        private static int Fibonacci(int n)
        {
            var fibonacci1 = 1;
            var fibonacci2 = 1;

            for (var i = 2; i < n; ++i)
            {
                var tempFibonacci = fibonacci2;
                fibonacci2 += fibonacci1;
                fibonacci1 = tempFibonacci;
            }

            return fibonacci2;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine($"Fibonacci(3): {Fibonacci(3)}");
        }
    }
}
