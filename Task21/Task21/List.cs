// <copyright file="List.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Task21
{
    using System;

    /// <summary>
    /// Class provides list structure.
    /// </summary>
    public class List
    {
        /// <summary>
        /// Pointer to the first element in the list.
        /// </summary>
        private ListElement head;

        /// <summary>
        /// Length of the list.
        /// </summary>
        private int length;

        /// <summary>
        /// Initializes a new instance of the <see cref="List"/> class.
        /// </summary>
        public List()
        {
            this.head = null;
            this.length = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="List"/> class.
        /// </summary>
        /// <param name="array">Array of items that will be added in the list</param>
        public List(int[] array)
        {
            if (array.Length == 0)
            {
                this.head = null;
                this.length = 0;
                return;
            }

            this.head = new ListElement(array[0], null);
            var prev = this.head;

            for (var i = 1; i < array.Length; ++i)
            {
                prev.Next = new ListElement(array[i], null);
                prev = prev.Next;
            }

            this.length = array.Length;
        }

        /// <summary>
        /// Returns element value at given position.
        /// </summary>
        /// <param name="position">Position of element which value will be returned</param>
        /// <returns>Element value at given position</returns>
        /// <exception cref="ArgumentOutOfRangeException">Position out of range</exception>
        public int GetValue(int position)
            => this.GetNode(position).Data;

        /// <summary>
        /// Sets element value at given position.
        /// </summary>
        /// <param name="position">Position of element which value will be changed</param>
        /// <param name="value">Value that will be set</param>
        /// <exception cref="ArgumentOutOfRangeException">Position out of range</exception>
        public void SetValue(int position, int value)
            => this.GetNode(position).Data = value;

        /// <summary>
        /// Inserts a new element in the list.
        /// </summary>
        /// <param name="position">Position of new element</param>
        /// <param name="value">Value of new element</param>
        /// <exception cref="ArgumentOutOfRangeException">Position out of range</exception>
        public void Insert(int position, int value)
        {
            var newNode = new ListElement(value, null);

            if (position == 0)
            {
                var tempNode = this.head;
                this.head = newNode;
                newNode.Next = tempNode;
            }
            else
            {
                var prevNode = this.GetNode(position - 1);
                newNode.Next = prevNode.Next;
                prevNode.Next = newNode;
            }

            ++this.length;
        }

        /// <summary>
        /// Removes element at given position.
        /// </summary>
        /// <param name="position">Position of element that will be removed</param>
        /// <exception cref="ArgumentOutOfRangeException">Position out of range</exception>
        public void Remove(int position)
        {
            if (position == 0 && this.length != 0)
            {
                this.head = this.head.Next;
            }
            else
            {
                var prevNode = this.GetNode(position - 1);
                prevNode.Next = this.GetNode(position).Next;
            }

            --this.length;
        }

        /// <summary>
        /// Returns length of the list.
        /// </summary>
        /// <returns>length of the list.</returns>
        public int Length()
            => this.length;

        /// <summary>
        /// Returns true if list is empty or false otherwise.
        /// </summary>
        /// <returns>true if list if empty or false otherwise</returns>
        public bool IsEmpty()
            => this.length == 0;

        /// <summary>
        /// Returns string representation of the list.
        /// </summary>
        /// <returns>string representation of the list</returns>
        public override string ToString()
        {
            var listString = "List: ";

            if (this.head == null)
            {
                return listString;
            }

            listString += $"{this.head.Data}";

            var currentNode = this.head.Next;
            while (currentNode != null)
            {
                listString += $", {currentNode.Data}";

                currentNode = currentNode.Next;
            }

            return listString;
        }

        /// <summary>
        /// Returns pointer to the element at given position.
        /// </summary>
        /// <param name="position">Position of element that will be returned.</param>
        /// <returns>pointer to the element</returns>
        /// <exception cref="ArgumentOutOfRangeException">Position out of range</exception>
        private ListElement GetNode(int position)
        {
            if (position < 0 || position >= this.length)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }

            var currentNode = this.head;
            for (var i = 0; i < position; ++i)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }

        /// <summary>
        /// Represents class for list element.
        /// </summary>
        private class ListElement
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ListElement"/> class.
            /// </summary>
            /// <param name="data">Value of the element</param>
            /// <param name="next">Pointer to the next element in list or null if last</param>
            public ListElement(int data, ListElement next)
            {
                this.Data = data;
                this.Next = next;
            }

            /// <summary>
            /// Gets or sets value of the element.
            /// </summary>
            public int Data { get; set; }

            /// <summary>
            /// Gets or sets pointer to the next element in list or null if last.
            /// </summary>
            public ListElement Next { get; set; }
        }
    }
}
