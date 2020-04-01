// <copyright file="StackArray.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Task23
{
    using System;

    /// <summary>
    /// Provides class for LIFO structure implemented with array.
    /// </summary>
    public class StackArray : IStack
    {
        /// <summary>
        /// Size of array.
        /// </summary>
        private int maxSize = 10;
        
        /// <summary>
        /// Array for store values.
        /// </summary>
        private int[] array;

        /// <summary>
        /// Position of first empty element in array.
        /// </summary>
        private int head;

        /// <summary>
        /// Initializes a new instance of the <see cref="StackArray"/> class.
        /// </summary>
        public StackArray()
        {
            this.array = new int[this.maxSize];
        }

        /// <summary>
        /// Added a new element to the stack. Resizes array if required.
        /// </summary>
        /// <param name="value">Value of the new element.</param>
        public void Push(int value)
        {
            if (this.head >= this.maxSize)
            {
                this.Resize();
            }

            this.array[this.head] = value;
            ++this.head;
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

            var popValue = this.array[this.head - 1];
            --this.head;
            return popValue;
        }

        /// <summary>
        /// Returns true if stack is empty or false otherwise.
        /// </summary>
        /// <returns>true fi stack is empty or false otherwise.</returns>
        public bool IsEmpty()
            => this.head == 0;

        /// <summary>
        /// Returns length of the stack.
        /// </summary>
        /// <returns>Length of the stack.</returns>
        public int GetLength()
            => this.head;

        /// <summary>
        /// Create a new array with double size. Copy all value from previous array to new.
        /// </summary>
        private void Resize()
        {
            var newMaxSize = 2 * this.maxSize;
            var newArray = new int[newMaxSize];

            for (var i = 0; i < this.GetLength(); ++i)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
            this.maxSize = newMaxSize;
        }
    }
}