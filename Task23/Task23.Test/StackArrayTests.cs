using System;
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
        public void PushThrowsExceptionAfterMaxSizeLimit()
        {
            for (var i = 0; i < stack.MaxSize; ++i) 
                stack.Push(1);

            Assert.Throws<InvalidOperationException>(delegate { stack.Push(1); });
        }

        [Test]
        public void PushWorkFineWithinMaxSizeLimit()
        {
            for (var i = 0; i < stack.MaxSize; ++i)
                stack.Push(1);
        }
    }
}