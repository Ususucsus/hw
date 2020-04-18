// <copyright file="List.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Task22
{
    using System;

    /// <summary>
    /// Represents a list of strings. Provides methods to insert, remove and change strings in the list.
    /// </summary>
    public class List
    {
        /// <summary>
        /// Head list element.
        /// </summary>
        private ListElement head;

        /// <summary>
        /// Length of the list.
        /// </summary>
        private int length;

        /// <summary>
        /// Initializes a new instance of the <see cref="List"/> class.
        /// </summary>
        /// <param name="array">Array from which the list will be built.</param>
        public List(string[] array)
        {
            if (array.Length == 0)
            {
                this.head = null;
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
        /// Initializes a new instance of the <see cref="List"/> class.
        /// </summary>
        public List()
        {
            this.head = null;
        }

        /// <summary>
        /// Returns value of element at given position.
        /// </summary>
        /// <param name="position">Position of element which should be returned.</param>
        /// <exception cref="ArgumentOutOfRangeException">Position is less than 0 or more or equal than length of the list.</exception>
        /// <returns>Value of element at given position.</returns>
        public string GetValue(int position)
            => this.GetNode(position).Data;

        /// <summary>
        /// Set value of element at given position.
        /// </summary>
        /// <param name="position">Position of element which value should be changed.</param>
        /// <param name="value">Value which should be set.</param>
        /// <exception cref="ArgumentOutOfRangeException">Position is less than 0 or more or equal than length of the list.</exception>
        public void SetValue(int position, string value)
            => this.GetNode(position).Data = value;

        /// <summary>
        /// Inserts new list element to given position.
        /// </summary>
        /// <param name="position">Position of the new list element.</param>
        /// <param name="value">Value of the new list element.</param>
        /// <exception cref="ArgumentOutOfRangeException">Position is less than 0 or more than length of the list.</exception>
        public void Insert(int position, string value)
        {
            if (position < 0 || position > this.length)
            {
                throw new ArgumentOutOfRangeException();
            }

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
        /// Removes list element at given position.
        /// </summary>
        /// <param name="position">Position of element which should be removed.</param>
        /// <exception cref="ArgumentOutOfRangeException">Position is less than 0 or more or equal than length of the list.</exception>
        public void Remove(int position)
        {
            if (position < 0 || position >= this.length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (position == 0)
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
        /// <returns>Length of the list.</returns>
        public int Length()
            => this.length;

        /// <summary>
        /// Checks if the list is empty.
        /// </summary>
        /// <returns>true if the list is empty, false otherwise.</returns>
        public bool IsEmpty()
            => this.length == 0;

        /// <summary>
        /// Returns string representation of the list.
        /// </summary>
        /// <returns>String representation of the list.</returns>
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
        /// Returns list element at given position.
        /// </summary>
        /// <param name="position">Position of element which should be returned.</param>
        /// <returns>List element at given position or null when list element isn't exist at given position.</returns>
        private ListElement GetNode(int position)
        {
            if (position < 0 || position >= this.length)
            {
                throw new ArgumentOutOfRangeException();
            }

            var currentNode = this.head;
            for (var i = 0; i < position; ++i)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }

        /// <summary>
        /// Represents a list element with data and pointer to next list element.
        /// </summary>
        private class ListElement
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ListElement"/> class.
            /// </summary>
            /// <param name="data">String value.</param>
            /// <param name="next">Pointer to next list element.</param>
            public ListElement(string data, ListElement next)
            {
                this.Data = data;
                this.Next = next;
            }

            /// <summary>
            /// Gets or sets list element value.
            /// </summary>
            public string Data { get; set; }

            /// <summary>
            /// Gets or sets pointer to next list element.
            /// </summary>
            public ListElement Next { get; set; }
        }
    }
}