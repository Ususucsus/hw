using System;

namespace Task23
{
    internal class StackList : IStack
    {
        private StackElement head;
        private int length;

        public void Push(int value)
        {
            head = new StackElement(value, head);
            ++length;
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var popValue = head.Data;
            head = head.Next;

            --length;

            return popValue;
        }

        public bool IsEmpty()
            => head == null;

        public int GetLength()
            => length;

        private class StackElement
        {
            public readonly int Data;
            public readonly StackElement Next;

            public StackElement(int data, StackElement next)
            {
                Data = data;
                Next = next;
            }
        }
    }
}