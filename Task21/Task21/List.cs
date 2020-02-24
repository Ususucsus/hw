using System;
using System.Collections.Generic;
using System.Text;

namespace Task21
{
    internal class List
    {
        private class Node
        {
            public Node(int data, Node next)
            {
                this.Data = data;
                this.Next = next;
            }

            public int Data;
            public Node Next;
        }

        public List(int[] array)
        {
            if (array.Length == 0)
            {
                head = null;
                return;
            }

            head = new Node(array[0], null);
            var prev = head;

            for (var i = 1; i < array.Length; ++i)
            {
                prev.Next = new Node(array[i], null);
                prev = prev.Next;
            }

            this.length = array.Length;
        }

        public int GetValue(int position)
        {
            if (position < 0 || position >= length)
                throw new ArgumentOutOfRangeException();

            return GetNode(position).Data;
        }

        public void SetValue(int position, int value)
        {
            if (position < 0 || position >= length)
                throw new ArgumentOutOfRangeException();

            GetNode(position).Data = value;
        }

        public void Insert(int position, int value)
        {
            if (position < 0 || position > length)
                throw new ArgumentOutOfRangeException();

            var newNode = new Node(value, null);

            if (position == 0)
            {
                var tempNode = head;
                head = newNode;
                newNode.Next = tempNode;
            }
            else
            {
                var prevNode = GetNode(position - 1);
                newNode.Next = prevNode.Next;
                prevNode.Next = newNode;
            }

            ++length;
        }

        public void Remove(int position)
        {
            if (position < 0 || position >= length)
                throw new ArgumentOutOfRangeException();

            if (position == 0)
                head = head.Next;
            else
            {
                var prevNode = GetNode(position - 1);
                prevNode.Next = GetNode(position).Next;
            }

            --length;
        }

        public int Length()
            => this.length;

        public bool IsEmpty()
            => this.length == 0;

        private Node GetNode(int position)
        {
            if (position < 0 || position >= length)
                return null;

            var currentNode = head;
            for (var i = 0; i < position; ++i)
                currentNode = currentNode.Next;

            return currentNode;
        }

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

        private Node head;
        private int length;
    }
}
