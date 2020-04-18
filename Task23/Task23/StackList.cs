// <copyright file="StackList.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Task23
{
    using System;

    /// <summary>
    /// Provides class for LIFO structure implemented with list.
    /// </summary>
    public class StackList : IStack
    {
        /// <summary>
        /// Pointer to the top stack element.
        /// </summary>
        private StackElement head;

        /// <summary>
        /// Length of the stack.
        /// </summary>
        private int length;

        /// <summary>
        /// Adds new element to the stack.
        /// </summary>
        /// <param name="value">Value of the new element.</param>
        public void Push(int value)
        {
            this.head = new StackElement(value, this.head);
            ++this.length;
        }

        /// <summary>
        /// Removed top element from the stack and returns it.
        /// </summary>
        /// <returns>Top stack element value.</returns>
        /// <exception cref="InvalidOperationException">If stack is empty.</exception>
        public int Pop()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException();
            }

            var popValue = this.head.Data;
            this.head = this.head.Next;

            --this.length;

            return popValue;
        }

        /// <summary>
        /// Returns true if stack is empty or false otherwise.
        /// </summary>
        /// <returns>true fi stack is empty or false otherwise.</returns>
        public bool IsEmpty()
            => this.head == null;

        /// <summary>
        /// Returns length of the stack.
        /// </summary>
        /// <returns>Length of the stack.</returns>
        public int GetLength()
            => this.length;

        /// <summary>
        /// Provides class for stack element.
        /// </summary>
        private class StackElement
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="StackElement"/> class.
            /// </summary>
            /// <param name="data">Value of the element.</param>
            /// <param name="next">Pointer to the next element or null.</param>
            public StackElement(int data, StackElement next)
            {
                this.Data = data;
                this.Next = next;
            }

            /// <summary>
            /// Gets value of the element.
            /// </summary>
            public int Data { get; }

            /// <summary>
            /// Gets pointer to the next element in the stack or null.
            /// </summary>
            public StackElement Next { get; }
        }
    }
}