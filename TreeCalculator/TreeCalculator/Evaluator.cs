namespace TreeCalculator
{
    using System;

    /// <summary>
    /// Represents class for evaluate string expressions.
    /// </summary>
    public class Evaluator
    {
        private string[] operandsFlow;
        private int currentOperandIndex = 0;

        /// <summary>
        /// Returns result of given expression.
        /// </summary>
        /// <param name="expression">Expression which will be calculated</param>
        /// <returns>Calculation result</returns>
        /// <exception cref="InvalidOperationException">Invalid expression format</exception>
        /// <exception cref="DivideByZeroException">Divide by zero in calculations</exception>
        public int EvaluateExpression(string expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            this.operandsFlow = expression.Split(new[] {'(', ')', ' '}, StringSplitOptions.RemoveEmptyEntries);

            var treeCalculator = BuildTreeCalculator();

            Console.WriteLine("Built tree:");
            PrintTreeCalculator(treeCalculator);

            var result = treeCalculator.Evaluate();

            return result;
        }

        /// <summary>
        /// Builds tree calculator based on given expression.
        /// </summary>
        /// <returns>Pointer to the first operation tree element</returns>
        /// <exception cref="InvalidOperationException">Invalid expression format</exception>
        private OperationTreeElement BuildTreeCalculator()
        {
            if (this.currentOperandIndex >= this.operandsFlow.Length)
                throw new InvalidOperationException("Invalid expression");

            var operation = this.operandsFlow[this.currentOperandIndex++];

            ITreeElement firstSubTree;
            ITreeElement secondSubTree;

            if (this.currentOperandIndex >= this.operandsFlow.Length)
                throw new InvalidOperationException("Invalid expression");

            if (int.TryParse(this.operandsFlow[this.currentOperandIndex], out var firstValue))
                firstSubTree = new ValueTreeElement(firstValue);
            else
                firstSubTree = BuildTreeCalculator();

            ++this.currentOperandIndex;

            if (this.currentOperandIndex >= this.operandsFlow.Length)
                throw new InvalidOperationException("Invalid expression");

            if (int.TryParse(this.operandsFlow[this.currentOperandIndex], out var secondValue))
                secondSubTree = new ValueTreeElement(secondValue);
            else
                secondSubTree = BuildTreeCalculator();

            return operation switch
            {
                "+" => new AdditionOperationTreeElement(firstSubTree, secondSubTree),
                "-" => new SubtractionOperationTreeElement(firstSubTree, secondSubTree),
                "*" => new MultiplicationOperationTreeElement(firstSubTree, secondSubTree),
                "/" => new DivisionOperationTreeElement(firstSubTree, secondSubTree),
                _ => throw new InvalidOperationException("Invalid expression")
            };
        }

        /// <summary>
        /// Prints tree.
        /// <param name="node">Pointer to node</param>
        /// <param name="offset">Offset for printing</param>
        /// </summary>
        private static void PrintTreeCalculator(ITreeElement node, int offset = 0)
        {
            while (true)
            {
                if (node == null) return;
                PrintTreeCalculator(node.LeftTreeElement, offset + 3);
                for (var i = 0; i < offset; ++i) Console.Write(" ");
                Console.WriteLine(node);
                node = node.RightTreeElement;
                offset += 3;
            }
        }
    }
}