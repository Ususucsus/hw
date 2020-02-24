namespace Task23
{
    internal class StackCalculator
    {
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
            var value2 = stack.Pop();
            var value1 = stack.Pop();

            stack.Push(value1 + value2);
        }

        public void Subtract()
        {
            var value2 = stack.Pop();
            var value1 = stack.Pop();

            stack.Push(value1 - value2);
        }

        public void Multiply()
        {
            var value2 = stack.Pop();
            var value1 = stack.Pop();

            stack.Push(value1 * value2);
        }

        public void Divide()
        {
            var value2 = stack.Pop();
            var value1 = stack.Pop();

            stack.Push(value1 / value2);
        }

        private readonly IStack stack;
    }
}
