using System;

namespace Task12
{
    class Program
    {
        private static int Fibonacci(int n)
        {
            var fib1 = 1;
            var fib2 = 1;

            for (var i = 2; i < n; ++i)
            {
                var tempFib = fib2;
                fib2 += fib1;
                fib1 = tempFib;
            }

            return fib2;
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Fibonacci(3): {Fibonacci(3)}");
        }
    }
}
