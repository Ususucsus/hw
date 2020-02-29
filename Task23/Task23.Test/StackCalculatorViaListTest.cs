using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using NUnit.Framework;

namespace Task23.Test
{
    class StackCalculatorViaListTest
    {
        private StackCalculator stackCalculator;

        [SetUp]
        public void Setup()
        {
            stackCalculator = new StackCalculator(new StackList());
        }

        [Test]
        public void AdditionTwoPositiveValuesGivesCorrectAnswer()
        {
            stackCalculator.Push(99);
            stackCalculator.Push(99);
            stackCalculator.Add();
            
            Assert.AreEqual(stackCalculator.Pop(), 198);
        }

        [Test]
        public void AdditionTwoNegativeValuesGivesCorrectAnswer()
        {
            stackCalculator.Push(-99);
            stackCalculator.Push(-99);
            stackCalculator.Add();

            Assert.AreEqual(stackCalculator.Pop(), -198);
        }

        [Test]
        public void AdditionPositiveAndNegativeValuesGivesCorrectAnswer()
        {
            stackCalculator.Push(-80);
            stackCalculator.Push(99);
            stackCalculator.Add();

            Assert.AreEqual(stackCalculator.Pop(), 19);
        }

        [Test]
        public void AdditionValuesWithZeroResultGivesCorrectAnswer()
        {
            stackCalculator.Push(99);
            stackCalculator.Push(-99);
            stackCalculator.Add();

            Assert.AreEqual(stackCalculator.Pop(), 0);
        }

        [Test]
        public void AdditionTwoZerosGivesCorrectAnswer()
        {
            stackCalculator.Push(0);
            stackCalculator.Push(0);
            stackCalculator.Add();

            Assert.AreEqual(stackCalculator.Pop(), 0);
;       }

        [Test]
        public void SubtractionTwoPositiveValuesGivesCorrectAnswer()
        {
            stackCalculator.Push(99);
            stackCalculator.Push(10);
            stackCalculator.Subtract();

            Assert.AreEqual(stackCalculator.Pop(), 89);
        }

        [Test]
        public void SubtractionTwoNegativeValuesGivesCorrectAnswer()
        {
            stackCalculator.Push(-99);
            stackCalculator.Push(-10);
            stackCalculator.Subtract();

            Assert.AreEqual(stackCalculator.Pop(), -89);
        }

        [Test]
        public void SubtractionPositiveAndNegativeValuesGivesCorrectAnswer()
        {
            stackCalculator.Push(-80);
            stackCalculator.Push(90);
            stackCalculator.Subtract();

            Assert.AreEqual(stackCalculator.Pop(), -170);
        }

        [Test]
        public void SubtractionValuesWithZeroResultGivesCorrectAnswer()
        {
            stackCalculator.Push(-99);
            stackCalculator.Push(-99);
            stackCalculator.Subtract();

            Assert.AreEqual(stackCalculator.Pop(), 0);
        }

        [Test]
        public void SubtractionTwoZerosGivesCorrectAnswer()
        {
            stackCalculator.Push(0);
            stackCalculator.Push(0);
            stackCalculator.Subtract();

            Assert.AreEqual(stackCalculator.Pop(), 0);
        }

        [Test]
        public void MultiplicationTwoPositiveValuesGivesCorrectAnswer()
        {
            stackCalculator.Push(99);
            stackCalculator.Push(99);
            stackCalculator.Multiply();

            Assert.AreEqual(stackCalculator.Pop(), 9801);
        }

        [Test]
        public void MultiplicationTwoNegativeValuesGivesCorrectAnswer()
        {
            stackCalculator.Push(-99);
            stackCalculator.Push(-99);
            stackCalculator.Multiply();

            Assert.AreEqual(stackCalculator.Pop(), 9801);
        }

        [Test]
        public void MultiplicationPositiveAndNegativeValuesGivesCorrectAnswer()
        {
            stackCalculator.Push(-99);
            stackCalculator.Push(99);
            stackCalculator.Multiply();

            Assert.AreEqual(stackCalculator.Pop(), -9801);
        }

        [Test]
        public void MultiplicationValuesWithZeroResultGivesCorrectAnswer()
        {
            stackCalculator.Push(-99);
            stackCalculator.Push(0);
            stackCalculator.Multiply();

            Assert.AreEqual(stackCalculator.Pop(), 0);
        }

        [Test]
        public void MultiplicationTwoZerosGivesCorrectAnswer()
        {
            stackCalculator.Push(0);
            stackCalculator.Push(0);
            stackCalculator.Multiply();

            Assert.AreEqual(stackCalculator.Pop(), 0);
            ;
        }

        [Test]
        public void DividingTwoPositiveValuesGivesCorrectAnswer()
        {
            stackCalculator.Push(99);
            stackCalculator.Push(5);
            stackCalculator.Divide();

            Assert.AreEqual(stackCalculator.Pop(), 19);
        }

        [Test]
        public void DividingTwoNegativeValuesGivesCorrectAnswer()
        {
            stackCalculator.Push(-99);
            stackCalculator.Push(-5);
            stackCalculator.Divide();

            Assert.AreEqual(stackCalculator.Pop(), 19);
        }

        [Test]
        public void DividingPositiveAndNegativeValuesGivesCorrectAnswer()
        {
            stackCalculator.Push(-99);
            stackCalculator.Push(5);
            stackCalculator.Divide();

            Assert.AreEqual(stackCalculator.Pop(), -19);
        }

        [Test]
        public void DividingLessByMoreGivesCorrectAnswer()
        {
            stackCalculator.Push(5);
            stackCalculator.Push(-10);
            stackCalculator.Divide();
            
            Assert.AreEqual(stackCalculator.Pop(), 0);

        }

        [Test]
        public void DividingByZeroThrowsException()
        {
            stackCalculator.Push(10);
            stackCalculator.Push(0);

            Assert.Throws<DivideByZeroException>(delegate { stackCalculator.Divide(); });
        }

        [Test]
        public void DividingZeroByValueGivesZero()
        {
            stackCalculator.Push(0);
            stackCalculator.Push(10);
            stackCalculator.Divide();

            Assert.AreEqual(stackCalculator.Pop(), 0);
        }

        [Test]
        public void OperationOnEmptyStackShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(delegate { stackCalculator.Add(); });
        }

        [Test]
        public void OperationOnStackWithOnlyOneElementShouldThrowException()
        {
            stackCalculator.Push(1);

            Assert.Throws<InvalidOperationException>(delegate { stackCalculator.Add(); });
        }

    }
}
