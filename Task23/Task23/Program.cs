using System;

namespace Task23
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IStack testStack = null;

            while (testStack == null)
            {
                Console.WriteLine("Enter stack type:");
                var stackType = Console.ReadLine();

                switch (stackType?.ToLower())
                {
                    case "array":
                        testStack = new StackArray();
                        break;
                    case "list":
                        testStack = new StackList();
                        break;
                    default:
                        Console.WriteLine("Failed.");
                        break;
                }
            }

            var testStackCalculator = new StackCalculator(testStack);

            var active = true;

            while (active)
            {
                var inputString = Console.ReadLine();

                try
                {
                    switch (inputString?.ToLower())
                    {
                        case "result":
                            Console.WriteLine(testStackCalculator.Pop());
                            active = false;
                            break;
                        case "+":
                            testStackCalculator.Add();
                            break;
                        case "-":
                            testStackCalculator.Subtract();
                            break;
                        case "*":
                            testStackCalculator.Multiply();
                            break;
                        case "/":
                            testStackCalculator.Divide();
                            break;
                        default:
                        {
                            if (int.TryParse(inputString, out var number) == false)
                                Console.WriteLine("Wrong input.");
                            else
                                testStackCalculator.Push(number);

                            break;
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Wrong operation.");
                }
            }
        }
    }
}