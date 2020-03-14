using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;

namespace TreeCalculator.Test
{
    public class ValueListElementTests
    {
        private ValueListElement listElement;

        [SetUp]
        public void Setup()
        {
            listElement = new ValueListElement(5);
        }

        [Test]
        public void EvaluateShouldReturnCorrectValue()
        {
            Assert.AreEqual(this.listElement.Evaluate(), 5);
        }

        [Test]
        public void ToStringShouldReturnCorrectString()
        {
            Assert.AreEqual(this.listElement.ToString(), "5");
        }

        [Test]
        public void GetsAnsSetsSubTreesShouldWorkCorrect()
        {
            this.listElement.LeftTreeElement = new ValueListElement(4);
            this.listElement.RightTreeElement = new ValueListElement(6);

            Assert.AreEqual(this.listElement.LeftTreeElement.Evaluate(), 4);
            Assert.AreEqual(this.listElement.RightTreeElement.Evaluate(), 6);
        }
    }
}