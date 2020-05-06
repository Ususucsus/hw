// <copyright file="Program.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace TreeCalculator
{
    using System;
    using System.IO;

    internal class Program
    {
        public static void Main()
        {
            var evaluator = new Evaluator();

            const string path = "expression.txt";

            using var file = new StreamReader(path);

            var expressionLine = file.ReadLine();
            Console.WriteLine($"Result: {evaluator.EvaluateExpression(expressionLine)}");
        }
    }
}
