using NUnit.Framework;

namespace Task23.Test
{
    public class StackArrayTests
    {
        private StackArray stack;

        [SetUp]
        public void Setup()
        {
            stack = new StackArray();
        }

        [Test]
        public void PushWithResizeWorkCorrect()
        {
            for (var i = 0; i < 1000; ++i)
            {
                stack.Push(1);
            }
        }
    }
}