// <copyright file="IStack.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Task23
{
    using System;

    /// <summary>
    /// Provides interface for LIFO structure.
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Adds new element to the stack.
        /// </summary>
        /// <param name="value">Value of the new element.</param>
        void Push(int value);

        /// <summary>
        /// Removed top element from the stack and returns it.
        /// </summary>
        /// <returns>Top stack element value.</returns>
        /// <exception cref="InvalidOperationException">If stack is empty.</exception>
        int Pop();
        
        /// <summary>
        /// Returns true if stack is empty or false otherwise.
        /// </summary>
        /// <returns>true if stack is empty or false otherwise.</returns>
        bool IsEmpty();

        /// <summary>
        /// Returns length of the stack.
        /// </summary>
        /// <returns>Length of the stack.</returns>
        int GetLength();
    }
}