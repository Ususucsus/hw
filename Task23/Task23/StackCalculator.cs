using System;

namespace Task23
{
    public class StackCalculator
    {
        private readonly IStack stack;

        public StackCalculator(IStack stack)
        {
            this.stack = stack;
        }

        public void Push(int value)
        {
            stack.Push(value);
        }

        public int Pop()
        {
            return stack.Pop();
        }

        public void Add()
        {
            if (stack.GetLength() < 2)
                throw new InvalidOperationException();

            var value2 = stack.Pop();
            var value1 = stack.Pop();

            stack.Push(value1 + value2);
        }

        public void Subtract()
        {
            if (stack.GetLength() < 2)
                throw new InvalidOperationException();

            var value2 = stack.Pop();
            var value1 = stack.Pop();

            stack.Push(value1 - value2);
        }

        public void Multiply()
        {
            if (stack.GetLength() < 2)
                throw new InvalidOperationException();

            var value2 = stack.Pop();
            var value1 = stack.Pop();

            stack.Push(value1 * value2);
        }

        public void Divide()
        {
            if (stack.GetLength() < 2)
                throw new InvalidOperationException();

            var value2 = stack.Pop();
            var value1 = stack.Pop();

            stack.Push(value1 / value2);
        }
    }
}