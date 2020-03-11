﻿using System;

namespace Task21
{
    /// <summary>
    /// Represents a list of integers. Provides methods to insert, remove and change integers in the list.
    /// </summary>
    public class List
    {
        /// <summary>
        /// Provides a list element with data and pointer to next list element.
        /// </summary>
        private class ListElement
        {
            /// <summary>
            /// Initializes a new instance of <see cref="ListElement"/> class.
            /// </summary>
            /// <param name="data">integer value</param>
            /// <param name="next">Pointer to next list element</param>
            public ListElement(int data, ListElement? next)
            {
                this.Data = data;
                this.Next = next;
            }

            /// <summary>
            /// List element value.
            /// </summary>
            public int Data;

            /// <summary>
            /// Pointer to next list element.
            /// </summary>
            public ListElement? Next;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="List"/> class.
        /// </summary>
        /// <param name="array">Array from which list will be build</param>
        public List(int[] array)
        {
            if (array.Length == 0)
            {
                head = null;
                return;
            }

            head = new ListElement(array[0], null);
            var prev = head;

            for (var i = 1; i < array.Length; ++i)
            {
                prev.Next = new ListElement(array[i], null);
                prev = prev.Next;
            }

            this.length = array.Length;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="List"/> class.
        /// </summary>
        public List()
        {
            head = null;
        }

        /// <summary>
        /// Returns value of element at given position.
        /// </summary>
        /// <param name="position">Position of element which value should be returned</param>
        /// <exception cref="ArgumentOutOfRangeException">Position is less than 0 or more or equal than length of the list</exception>
        /// <returns>Value of element</returns>
        public int GetValue(int position)
        {
            if (position < 0 || position >= length)
                throw new ArgumentOutOfRangeException();

            return GetNode(position)!.Data;
        }

        /// <summary>
        /// Set value of element at given position.
        /// </summary>
        /// <param name="position">Position of element which value should be changed</param>
        /// <param name="value">Value which should be set</param>
        /// <exception cref="ArgumentOutOfRangeException">Position is less than 0 or more or equal than length of the list</exception>
        public void SetValue(int position, int value)
        {
            if (position < 0 || position >= length)
                throw new ArgumentOutOfRangeException();

            GetNode(position)!.Data = value;
        }

        /// <summary>
        /// Inserts new list element to given position.
        /// </summary>
        /// <param name="position">Position of the new list element</param>
        /// <param name="value">Value of the new list element</param>
        /// <exception cref="ArgumentOutOfRangeException">Position is less than 0 or more than length of the list</exception>
        public void Insert(int position, int value)
        {
            if (position < 0 || position > length)
                throw new ArgumentOutOfRangeException();

            var newNode = new ListElement(value, null);

            if (position == 0)
            {
                var tempNode = head;
                head = newNode;
                newNode.Next = tempNode;
            }
            else
            {
                var prevNode = GetNode(position - 1);
                newNode.Next = prevNode!.Next;
                prevNode.Next = newNode;
            }

            ++length;
        }

        /// <summary>
        /// Removes list element at given position.
        /// </summary>
        /// <param name="position">Position of element which should be removed</param>
        /// <exception cref="ArgumentOutOfRangeException">Position is less than 0 or more or equal than length of the list</exception>
        public void Remove(int position)
        {
            if (position < 0 || position >= length)
                throw new ArgumentOutOfRangeException();

            if (position == 0)
                head = head!.Next;
            else
            {
                var prevNode = GetNode(position - 1);
                prevNode!.Next = GetNode(position)!.Next;
            }

            --length;
        }

        /// <summary>
        /// Checks if value contains in list.
        /// </summary>
        /// <param name="value">Value to be checked</param>
        /// <returns>true if value contains in list, false otherwise</returns>
        public bool ContainsValue(int value)
        {
            var currentListElement = head;
            while (currentListElement != null)
            {
                if (currentListElement.Data == value)
                    return true;

                currentListElement = head!.Next;
            }

            return false;
        }

        /// <summary>
        /// Returns length of the list.
        /// </summary>
        /// <returns>Length of the list</returns>
        public int Length()
            => this.length;

        /// <summary>
        /// Checks if the list is empty.
        /// </summary>
        /// <returns>true if the list is empty, false otherwise</returns>
        public bool IsEmpty()
            => this.length == 0;

        /// <summary>
        /// Returns list element at given position.
        /// </summary>
        /// <param name="position">Position of element which should be returned.</param>
        /// <returns>List element at given position or null when list element isn't exist at given position</returns>
        private ListElement? GetNode(int position)
        {
            if (position < 0 || position >= length)
                return null;

            var currentNode = head;
            for (var i = 0; i < position; ++i)
                currentNode = currentNode!.Next;

            return currentNode;
        }

        /// <summary>
        /// Returns string representation of the list.
        /// </summary>
        /// <returns>string representation of the list</returns>
        public override string ToString()
        {
            var listString = "List: ";

            if (head == null)
                return listString;

            listString += $"{head.Data}";

            var currentNode = head.Next;
            while (currentNode != null)
            {
                listString += $", {currentNode.Data}";

                currentNode = currentNode.Next;
            }

            return listString;
        }

        /// <summary>
        /// Head list element.
        /// </summary>
        private ListElement? head;

        /// <summary>
        /// Length of the list.
        /// </summary>
        private int length;
    }
}
