using System;

namespace Task23
{
    internal class StackArray : IStack
    {
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
            if (this.IsEmpty())
                throw new InvalidOperationException();

            var popValue = array[head - 1];
            --head;
            return popValue;
        }

        public bool IsEmpty()
            => head == 0;

        private readonly int[] array;
        private int head;

        public const int MaxSize = 1000;
    }
}
