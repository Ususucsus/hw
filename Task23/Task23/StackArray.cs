using System;

namespace Task23
{
    internal class StackArray : IStack
    {
        public const int MaxSize = 1000;

        private readonly int[] array;
        private int head;

        public StackArray()
        {
            array = new int[1000];
        }

        public void Push(int value)
        {
            if (head >= 1000)
                throw new InvalidOperationException();

            array[head++] = value;
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var popValue = array[head - 1];
            --head;
            return popValue;
        }

        public bool IsEmpty()
            => head == 0;

        public int GetLength()
            => head;
    }
}