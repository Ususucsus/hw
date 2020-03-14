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
        public void GetsAnsSetsSubTreesShouldWorkCorrect()
        {
            this.treeElement.LeftTreeElement = new ValueTreeElement(4);
            this.treeElement.RightTreeElement = new ValueTreeElement(6);

            Assert.AreEqual(this.treeElement.LeftTreeElement.Evaluate(), 4);
            Assert.AreEqual(this.treeElement.RightTreeElement.Evaluate(), 6);
        }
    }
}