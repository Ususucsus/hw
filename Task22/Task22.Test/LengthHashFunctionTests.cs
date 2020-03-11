using NUnit.Framework;

namespace Task22.Test
{
    public class LengthHashFunctionTests
    {
        private LengthHashFunction hashFunction;

        [SetUp]
        public void Setup()
        {
            hashFunction = new LengthHashFunction();
        }

        [Test]
        public void HashOfEmptyStringShouldBeZero()
        {
            Assert.AreEqual(hashFunction.GetHashValue(""), 0);
        }

        [Test]
        public void HashOfNonEmptyStringShouldBeLengthOfTheString()
        {
            Assert.AreEqual(hashFunction.GetHashValue("kek"), 3);
        }
    }
}