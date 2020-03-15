using System;
using System.IO;

namespace TreeCalculator
{
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
