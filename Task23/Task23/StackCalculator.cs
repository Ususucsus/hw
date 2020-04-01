// <copyright file="StackCalculator.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Task23
{
    using System;

    /// <summary>
    /// Provides class for calculation.
    /// </summary>
    public class StackCalculator
    {
        /// <summary>
        /// Used stack.
        /// </summary>
        private readonly IStack stack;

        /// <summary>
        /// Initializes a new instance of the <see cref="StackCalculator"/> class.
        /// </summary>
        /// <param name="stack">Stack object.</param>
        public StackCalculator(IStack stack)
        {
            this.stack = stack;
        }

        /// <summary>
        /// Adds new element to the stack.
        /// </summary>
        /// <param name="value">Value of the element.</param>
        public void Push(int value)
            => this.stack.Push(value);

        /// <summary>
        /// Removes element from the stack and returns it.
        /// </summary>
        /// <returns>Top stack element value.</returns>
        public int Pop()
            => this.stack.Pop();

        /// <summary>
        /// Adds two top numbers from the stack.
        /// </summary>
        /// <exception cref="InvalidOperationException">If in stack less than two element.</exception>
        public void Add()
        {
            if (this.stack.GetLength() < 2)
            {
                throw new InvalidOperationException();
            }

            var value2 = this.stack.Pop();
            var value1 = this.stack.Pop();

            this.stack.Push(value1 + value2);
        }

        /// <summary>
        /// Subtracts two top numbers from the stack.
        /// </summary>
        /// <exception cref="InvalidOperationException">If in stack less than two element.</exception>
        public void Subtract()
        {
            if (this.stack.GetLength() < 2)
            {
                throw new InvalidOperationException();
            }

            var value2 = this.stack.Pop();
            var value1 = this.stack.Pop();

            this.stack.Push(value1 - value2);
        }

        /// <summary>
        /// Multiplies two top numbers from the stack.
        /// </summary>
        /// <exception cref="InvalidOperationException">If in stack less than two element.</exception>
        public void Multiply()
        {
            if (this.stack.GetLength() < 2)
            {
                throw new InvalidOperationException();
            }

            var value2 = this.stack.Pop();
            var value1 = this.stack.Pop();

            this.stack.Push(value1 * value2);
        }

        /// <summary>
        /// Divides two top numbers from the stack.
        /// </summary>
        /// <exception cref="InvalidOperationException">If in stack less than two element.</exception>
        /// <exception cref="DivideByZeroException">If second value is zero.</exception>
        public void Divide()
        {
            if (this.stack.GetLength() < 2)
            {
                throw new InvalidOperationException();
            }

            var value2 = this.stack.Pop();
            var value1 = this.stack.Pop();

            if (value2 == 0)
            {
                throw new DivideByZeroException();
            }

            this.stack.Push(value1 / value2);
        }
    }
}