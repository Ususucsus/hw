using System;

namespace Task23
{
    public class StackArray : IStack
    {
        public readonly int MaxSize = 1000;

        private readonly int[] array;
        private int head;

        public StackArray()
        {
            array = new int[MaxSize];
        }

        public void Push(int value)
        {
            if (head >= MaxSize)
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