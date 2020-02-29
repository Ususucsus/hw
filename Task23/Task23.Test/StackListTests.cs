﻿using System;
using NUnit.Framework;

namespace Task23.Test
{
    public class StackListTests
    {
        private StackList stack;

        [SetUp]
        public void Setup()
        {
            stack = new StackList();
        }

        [Test]
        public void InitiallyStackShouldBeEmpty()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public void AfterPushStackShouldNotBeEmpty()
        {
            stack.Push(1);

            Assert.IsFalse(stack.IsEmpty());
        }

        [Test]
        public void PushWorkFineWithinMaxSizeLimit()
        {
            for (var i = 0; i < 1000; ++i)
                stack.Push(1);
        }

        [Test]
        public void StackShouldWorkAsFILO()
        {
            stack.Push(1);
            stack.Push(2);

            Assert.AreEqual(stack.Pop(), 2);
        }

        [Test]
        public void PopShouldThrowExceptionWhenStackIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(delegate { stack.Pop(); });
        }

        [Test]
        public void LengthOfEmptyStackShouldBeZero()
        {
            Assert.AreEqual(stack.GetLength(), 0);
        }

        [Test]
        public void LengthAfterPushPopShouldBeZero()
        {
            stack.Push(1);
            stack.Pop();

            Assert.AreEqual(stack.GetLength(), 0);
        }

        [Test]
        public void LengthOfFilledStackShouldBeCorrect()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(stack.GetLength(), 3);
        }

        [Test]
        public void AfterPopLengthShouldDecrease()
        {
            stack.Push(2);
            stack.Push(2);

            var length = stack.GetLength();

            stack.Pop();

            Assert.AreEqual(stack.GetLength(), length - 1);
        }

    }
}