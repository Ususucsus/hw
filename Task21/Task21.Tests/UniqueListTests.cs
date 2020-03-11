using System;
using NUnit.Framework;

namespace Task21.Test
{
    public class UniqueListTests
    {
        private UniqueList uniqueList;

        [SetUp]
        public void Setup()
        {
            uniqueList = new UniqueList();
        }

        [Test]
        public void InsertDifferentElementsShouldWorkCorrect()
        {
            uniqueList.Insert(0, 1);
            uniqueList.Insert(1, 2);

            Assert.IsTrue(uniqueList.ContainsValue(1));
            Assert.IsTrue(uniqueList.ContainsValue(2));
        }

        [Test]
        public void InsertSameElementsShouldThrowException()
        {
            uniqueList.Insert(0, 1);

            Assert.Throws<ValueAlreadyExistException>(() => uniqueList.Insert(0, 1));
        }
    }
}