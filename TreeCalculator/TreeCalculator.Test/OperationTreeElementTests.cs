// <copyright file="OperationTreeElementTests.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace TreeCalculator.Test
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class OperationTreeElementTests
    {
        private static IEnumerable<TestCaseData> OperationsWithValueElements
            => new TestCaseData[]
            {
                new TestCaseData(
                    new AdditionOperationTreeElement(new ValueTreeElement(5), new ValueTreeElement(10)))
                    .Returns(15),
                new TestCaseData(
                    new SubtractionOperationTreeElement(new ValueTreeElement(0), new ValueTreeElement(20)))
                    .Returns(-20),
                new TestCaseData(
                    new MultiplicationOperationTreeElement(new ValueTreeElement(5), new ValueTreeElement(10)))
                    .Returns(50),
                new TestCaseData(
                    new DivisionOperationTreeElement(new ValueTreeElement(9), new ValueTreeElement(3)))
                    .Returns(3), 
            };

        private static IEnumerable<TestCaseData> OperationsWithOperationsElements
            => new TestCaseData[]
            {
                new TestCaseData(
                    new AdditionOperationTreeElement(
                        new ValueTreeElement(5),
                        new MultiplicationOperationTreeElement(new ValueTreeElement(3), new ValueTreeElement(4))))
                    .Returns(17), 
                new TestCaseData(
                    new SubtractionOperationTreeElement(
                        new DivisionOperationTreeElement(new ValueTreeElement(20), new ValueTreeElement(3)),
                        new ValueTreeElement(10)))
                    .Returns(-4), 
                new TestCaseData(
                    new MultiplicationOperationTreeElement(
                        new AdditionOperationTreeElement(new ValueTreeElement(10),  new ValueTreeElement(0)), 
                        new SubtractionOperationTreeElement(new ValueTreeElement(7),  new ValueTreeElement(2))))
                    .Returns(50),
                new TestCaseData(
                    new DivisionOperationTreeElement(
                        new MultiplicationOperationTreeElement(
                            new AdditionOperationTreeElement(new ValueTreeElement(50), new ValueTreeElement(50)), 
                            new ValueTreeElement(5)), 
                        new ValueTreeElement(100)))
                    .Returns(5), 
            };

        [Test]
        [TestCaseSource(nameof(OperationsWithValueElements))]
        public int OperationWithValueElementsShouldWorkCorrect(OperationTreeElement operationTreeElement)
            => operationTreeElement.Evaluate();

        [Test]
        [TestCaseSource(nameof(OperationsWithOperationsElements))]
        public int OperationWithOperationElementsShouldWorkCorrect(OperationTreeElement operationTreeElement)
            => operationTreeElement.Evaluate();

        [Test]
        public void AttemptToSetNullSubTreeShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new AdditionOperationTreeElement(
                    new ValueTreeElement(5), new ValueTreeElement(5)).LeftTreeElement = null);
            Assert.Throws<ArgumentNullException>(() =>
                new DivisionOperationTreeElement(
                    new ValueTreeElement(5), new ValueTreeElement(5)).LeftTreeElement = null);
            Assert.Throws<ArgumentNullException>(() =>
                new MultiplicationOperationTreeElement(
                    new ValueTreeElement(5), new ValueTreeElement(5)).RightTreeElement = null);
            Assert.Throws<ArgumentNullException>(() =>
                new SubtractionOperationTreeElement(
                    new ValueTreeElement(5), new ValueTreeElement(5)).RightTreeElement = null);
        }

        [Test]
        public void InitWithNullSubtreeShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new AdditionOperationTreeElement(null, null));
            Assert.Throws<ArgumentNullException>(
                () => new SubtractionOperationTreeElement(new ValueTreeElement(5), null));
            Assert.Throws<ArgumentNullException>(
                () => new MultiplicationOperationTreeElement(null, new ValueTreeElement(5)));
            Assert.Throws<ArgumentNullException>(() => new DivisionOperationTreeElement(null, null));
        }

        [Test]
        public void DivisionByZeroShouldThrowException()
        {
            Assert.Throws<DivideByZeroException>(() =>
                new DivisionOperationTreeElement(new ValueTreeElement(5), new ValueTreeElement(0)).Evaluate());
        }
    }
}