using System;
using NUnit.Framework;

namespace Task23.Test
{
    public class StackCalculatorTests
    {
        private StackCalculator stackCalculator;

        [SetUp]
        public void Setup()
        {
            stackCalculator = new StackCalculator(new StackArray());
        }

        [Test]
        [TestCase(99, 99, ExpectedResult = 198)]
        [TestCase(-99, -99, ExpectedResult = -198)]
        [TestCase(-80,  99, ExpectedResult = 19)]
        [TestCase(99, -99, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = 0)]
        public int AdditionShouldWorkCorrect(int value1, int value2)
        {
            stackCalculator.Push(value1);
            stackCalculator.Push(value2);
            stackCalculator.Add();

            return stackCalculator.Pop();
        }

        [Test]
        [TestCase(99, 10, ExpectedResult = 89)]
        [TestCase(-99, -10, ExpectedResult = -89)]
        [TestCase(-80, 90, ExpectedResult = -170)]
        [TestCase(-99, -99, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = 0)]
        public int SubtractionShouldWorkCorrect(int value1, int value2)
        {
            stackCalculator.Push(value1);
            stackCalculator.Push(value2);
            stackCalculator.Subtract();

            return stackCalculator.Pop();
        }

        [Test]
        [TestCase(99, 99, ExpectedResult = 9801)]
        [TestCase(-99, -99, ExpectedResult = 9801)]
        [TestCase(-99, 99, ExpectedResult = -9801)]
        [TestCase(-99, 0, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = 0)]
        public int MultiplicationShouldWorkCorrect(int value1, int value2)
        {
            stackCalculator.Push(value1);
            stackCalculator.Push(value2);
            stackCalculator.Multiply();

            return stackCalculator.Pop();
        }

        [Test]
        [TestCase(99, 5, ExpectedResult = 19)]
        [TestCase(-99, -5, ExpectedResult = 19)]
        [TestCase(-99, 5, ExpectedResult = -19)]
        [TestCase(5, -10, ExpectedResult = 0)]
        [TestCase(0, 10, ExpectedResult = 0)]
        public int DividingShouldWorkCorrect(int value1, int value2)
        {
            stackCalculator.Push(value1);
            stackCalculator.Push(value2);
            stackCalculator.Divide();

            return stackCalculator.Pop();
        }

        [Test]
        public void DividingByZeroThrowsException()
        {
            stackCalculator.Push(10);
            stackCalculator.Push(0);

            Assert.Throws<DivideByZeroException>(delegate { stackCalculator.Divide(); });
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
