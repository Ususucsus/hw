using System;

namespace Task23
{
    /// <summary>
    /// Class that implements calculations in a postfix notation.
    /// </summary>
    public class StackCalculator
    {
        /// <summary>
        /// Stack instance required to the calculations.
        /// </summary>
        private readonly IStack stack;

        /// <summary>
        /// Initializes a new instance of the <see cref="StackCalculator"/> class.
        /// </summary>
        /// <param name="stack">Stack instance</param>
        public StackCalculator(IStack stack)
        {
            this.stack = stack;
        } 

        /// <summary>
        /// Add number to the stack.
        /// </summary>
        /// <param name="value">Value to be added</param>
        public void Push(int value)
        {
            stack.Push(value);
        }

        /// <summary>
        /// Removes top element from the stack and returns it.
        /// </summary>
        /// <returns>Top element of the stack</returns>
        public int Pop()
        {
            return stack.Pop();
        }

        /// <summary>
        /// Removes two top elements from the stack and push result of their addition.
        /// <exception cref="InvalidOperationException">If stack length less than two elements</exception>
        /// </summary>
        public void Add()
        {
            if (stack.GetLength() < 2)
                throw new InvalidOperationException();

            var value2 = stack.Pop();
            var value1 = stack.Pop();

            stack.Push(value1 + value2);
        }

        /// <summary>
        /// Removes two top elements from the stack and push result of their subtraction.
        /// <exception cref="InvalidOperationException">If stack length less than two elements</exception>
        /// </summary>
        public void Subtract()
        {
            if (stack.GetLength() < 2)
                throw new InvalidOperationException();

            var value2 = stack.Pop();
            var value1 = stack.Pop();

            stack.Push(value1 - value2);
        }

        /// <summary>
        /// Removes two top elements from the stack and push result of their multiplication.
        /// <exception cref="InvalidOperationException">If stack length less than two elements</exception>
        /// </summary>
        public void Multiply()
        {
            if (stack.GetLength() < 2)
                throw new InvalidOperationException();

            var value2 = stack.Pop();
            var value1 = stack.Pop();

            stack.Push(value1 * value2);
        }

        /// <summary>
        /// Removes two top elements from the stack and push result of their dividing.
        /// <exception cref="InvalidOperationException">If stack length less than two elements</exception>
        /// <exception cref="DivideByZeroException">If second element in calculations was zero</exception>
        /// </summary>
        public void Divide()
        {
            if (stack.GetLength() < 2)
                throw new InvalidOperationException();

            var value2 = stack.Pop();
            var value1 = stack.Pop();

            if (value2 == 0)
                throw new DivideByZeroException();

            stack.Push(value1 / value2);
        }
    }
}