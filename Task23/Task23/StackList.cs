using System;

namespace Task23
{
    internal class StackList : IStack
    {
        private class StackElement
        {
            public StackElement(int data, StackElement next)
            {
                this.Data = data;
                this.Next = next;
            }

            public readonly int Data;
            public readonly StackElement Next;
        }

        public void Push(int value)
        {
            head = new StackElement(value, head);
        }

        public int Pop()
        {
            if (this.IsEmpty())
                throw new InvalidOperationException();

            var popValue = head.Data;
            head = head.Next;

            return popValue;
        }

        public bool IsEmpty()
            => head == null;

        private StackElement head;

    }
}
