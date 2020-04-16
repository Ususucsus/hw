// <copyright file="Program.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Task23
{
    using System;

    public class Program
    {
        private static void Main()
        {
            IStack stack = null;

            while (stack == null)
            {
                Console.WriteLine("Enter stack type (array or list):");
                var stackType = Console.ReadLine();

                switch (stackType?.ToLower())
                {
                    case "array":
                        stack = new StackArray();
                        break;
                    case "list":
                        stack = new StackList();
                        break;
                    default:
                        Console.WriteLine("Failed.");
                        break;
                }
            }

            var stackCalculator = new StackCalculator(stack);

            var active = true;

            while (active)
            {
                Console.WriteLine("Enter number or operation (+, -, *, /):");
                var inputString = Console.ReadLine();

                try
                {
                    switch (inputString?.ToLower())
                    {
                        case "result":
                            Console.WriteLine(stackCalculator.Pop());
                            active = false;
                            break;
                        case "+":
                            stackCalculator.Add();
                            break;
                        case "-":
                            stackCalculator.Subtract();
                            break;
                        case "*":
                            stackCalculator.Multiply();
                            break;
                        case "/":
                            stackCalculator.Divide();
                            break;
                        default:
                        {
                            if (!int.TryParse(inputString, out var number))
                            {
                                Console.WriteLine("Wrong input.");
                            }
                            else
                            {
                                stackCalculator.Push(number);
                            }

                            break;
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Wrong operation.");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Zero division error");
                    active = false;
                }
            }
        }
    }
}