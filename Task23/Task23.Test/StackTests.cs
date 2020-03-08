using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Task23.Test
{
    public class StackTests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static IEnumerable<TestCaseData> Stacks
            => new TestCaseData[]
            {
                new TestCaseData(new StackArray()), 
                new TestCaseData(new StackList()), 
            };

        [Test]
        [TestCaseSource(nameof(Stacks))]
        public void InitiallyStackShouldBeEmpty(IStack stack)
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        [TestCaseSource(nameof(Stacks))]
        public void AfterPushStackShouldNotBeEmpty(IStack stack)
        {
            stack.Push(1);

            Assert.IsFalse(stack.IsEmpty());
        }

        [Test]
        [TestCaseSource(nameof(Stacks))]
        public void StackShouldWorkAsFILO(IStack stack)
        {
            stack.Push(1);
            stack.Push(2);

            Assert.AreEqual(stack.Pop(), 2);
        }

        [Test]
        [TestCaseSource(nameof(Stacks))]
        public void PopShouldThrowExceptionWhenStackIsEmpty(IStack stack)
        {
            Assert.Throws<InvalidOperationException>(delegate { stack.Pop(); });
        }

        [Test]
        [TestCaseSource(nameof(Stacks))]
        public void LengthOfEmptyStackShouldBeZero(IStack stack)
        {
            Assert.AreEqual(stack.GetLength(), 0);
        }

        [Test]
        [TestCaseSource(nameof(Stacks))]
        public void LengthAfterPushPopShouldBeZero(IStack stack)
        {
            stack.Push(1);
            stack.Pop();

            Assert.AreEqual(stack.GetLength(), 0);
        }

        [Test]
        [TestCaseSource(nameof(Stacks))]
        public void LengthOfFilledStackShouldBeCorrect(IStack stack)
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(stack.GetLength(), 3);
        }

        [Test]
        [TestCaseSource(nameof(Stacks))]
        public void AfterPopLengthShouldDecrease(IStack stack)
        {
            stack.Push(2);
            stack.Push(2);

            var length = stack.GetLength();

            stack.Pop();

            Assert.AreEqual(stack.GetLength(), length - 1);
        }
    }
}