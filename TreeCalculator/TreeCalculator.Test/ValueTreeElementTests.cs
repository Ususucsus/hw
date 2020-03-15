using System;

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
            Assert.AreEqual(this.treeElement.Evaluate(), 5);
        }

        [Test]
        public void ToStringShouldReturnCorrectString()
        {
            Assert.AreEqual(this.treeElement.ToString(), "5");
        }

        [Test]
        public void AttemptToSetSubTreeShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => treeElement.LeftTreeElement = new ValueTreeElement(5));
            Assert.Throws<InvalidOperationException>((() => treeElement.RightTreeElement = new ValueTreeElement(5)));
        }
    }
}