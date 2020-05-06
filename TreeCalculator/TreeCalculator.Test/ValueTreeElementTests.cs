// <copyright file="ValueTreeElementTests.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace TreeCalculator.Test
{
    using NUnit.Framework;

    public class ValueTreeElementTests
    {
        private ValueTreeElement treeElement;

        [SetUp]
        public void Setup()
        {
            this.treeElement = new ValueTreeElement(5);
        }

        [Test]
        public void EvaluateShouldReturnCorrectValue()
        {
            Assert.AreEqual(5, this.treeElement.Evaluate());
        }

        [Test]
        public void ToStringShouldReturnCorrectString()
        {
            Assert.AreEqual("5", this.treeElement.ToString());
        }
    }
}