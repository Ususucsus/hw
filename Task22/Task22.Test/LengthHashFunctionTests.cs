// <copyright file="LengthHashFunctionTests.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Task22.Test
{
    using NUnit.Framework;

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
            Assert.AreEqual(0, hashFunction.GetHashValue(""));
        }

        [Test]
        public void HashOfNonEmptyStringShouldBeLengthOfTheString()
        {
            Assert.AreEqual(3, hashFunction.GetHashValue("kek"));
        }
    }
}