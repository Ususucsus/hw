using System;

namespace Task23
{
    /// <summary>
    /// Stack implemented using an array.
    /// Maximum number of elements in the stack is equal to StackArray.MaxSize.
    /// </summary>
    public class StackArray : IStack
    {
        /// <summary>
        /// Maximum number of elements in the stack.
        /// </summary>
        public readonly int MaxSize = 1000;

        /// <summary>
        /// Array to store the stack data.
        /// </summary>
        private readonly int[] array;
        
        /// <summary>
        /// Index of the top of the stack in the array.
        /// </summary>
        private int head;

        /// <summary>
        /// Initializes a new instance of the <see cref="StackArray"/> class.
        /// </summary>
        public StackArray()
        {
            array = new int[MaxSize];
        }

        /// <summary>
        /// Adds element to the stack.
        /// </summary>
        /// <exception cref="InvalidOperationException">If maximum number of elements in the stack was exceeded</exception>
        /// <param name="value">Value to be pushed</param>
        public void Push(int value)
        {
            if (head >= MaxSize)
                throw new InvalidOperationException();

            array[head++] = value;
        }

        /// <summary>
        /// Removed top element from the stack and returns it.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the stack was empty</exception>
        /// <returns>Top element in the stack</returns>
        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var popValue = array[head - 1];
            --head;
            return popValue;
        }


        /// <summary>
        /// Checks is the stack is empty.
        /// </summary>
        /// <returns>True if stack is empty</returns>
        public bool IsEmpty()
            => head == 0;

        /// <summary>
        /// Returns length of the stack.
        /// </summary>
        /// <returns>Length of the stack</returns>
        public int GetLength()
            => head;
    }
}