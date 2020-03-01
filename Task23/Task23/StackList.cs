using System;

namespace Task23
{
    /// <summary>
    /// Stack implemented using an list.
    /// </summary>
    public class StackList : IStack
    {
        /// <summary>
        /// Top element of the stack.
        /// </summary>
        private StackElement head;

        /// <summary>
        /// Length of the stack.
        /// </summary>
        private int length;

        /// <summary>
        /// Adds element to the stack.
        /// </summary>
        /// <param name="value">Value to be pushed</param>
        public void Push(int value)
        {
            head = new StackElement(value, head);
            ++length;
        }

        /// <summary>
        /// Removes top element from the stack and returns it.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the stack was empty</exception>
        /// <returns>Top element of the stack</returns>
        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var popValue = head.Data;
            head = head.Next;

            --length;

            return popValue;
        }

        /// <summary>
        /// Checks is the stack is empty.
        /// </summary>
        /// <returns>True if stack is empty</returns>
        public bool IsEmpty()
            => head == null;

        /// <summary>
        /// Returns length of the stack.
        /// </summary>
        /// <returns>Length of the stack</returns>
        public int GetLength()
            => length;

        /// <summary>
        /// Class for contain node data.
        /// </summary>
        private class StackElement
        {
            /// <summary>
            /// Value of the node.
            /// </summary>
            public readonly int Data;

            /// <summary>
            /// Pointer to next node.
            /// </summary>
            public readonly StackElement Next;

            /// <summary>
            /// Initializes a new instance of the <see cref="StackElement"/> class.
            /// </summary>
            /// <param name="data">Value of the node</param>
            /// <param name="next">Pointer to next node</param>
            public StackElement(int data, StackElement next)
            {
                Data = data;
                Next = next;
            }
        }
    }
}