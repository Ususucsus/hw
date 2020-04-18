// <copyright file="HashTableTests.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Task22.Test
{
    using System;
    using NUnit.Framework;

    public class HashTableTests
    {
        private HashTable hashTable;

        [SetUp]
        public void Setup()
        {
            hashTable = new HashTable(5, new LengthHashFunction());
        }

        [Test]
        public void InsertedElementShouldBeContainedInHashtable()
        {
            hashTable.Insert("5");
            hashTable.Insert("4");

            Assert.IsTrue(hashTable.ContainsValue("5"));
            Assert.IsTrue(hashTable.ContainsValue("4"));
        }

        [Test]
        public void ElementShouldNotBeContainedIfHashtableIsEmpty()
        {
            Assert.IsFalse(hashTable.ContainsValue("5"));
        }

        [Test]
        public void ElementShouldNotBeContainedInHashtable()
        {
            hashTable.Insert("3");
            
            Assert.IsFalse(hashTable.ContainsValue("5"));
        }

        [Test]
        public void RemovedElementShouldNotBeContainedInHashtable()
        {
            hashTable.Insert("5");
            hashTable.Insert("4");

            hashTable.Remove("5");

            Assert.IsTrue(hashTable.ContainsValue("4"));
            Assert.IsFalse(hashTable.ContainsValue("5"));
        }

        [Test]
        public void RemoveElementThatIsNotContainedShouldWorkCorrect()
        {
            hashTable.Insert("5");
            hashTable.Remove("4");

            Assert.IsTrue(hashTable.ContainsValue("5"));
            Assert.IsFalse(hashTable.ContainsValue("4"));
        }

        [Test]
        public void InsertExistingElementShouldThrowException()
        {
            hashTable.Insert("5");

            Assert.Throws<ArgumentException>(() => hashTable.Insert("5"));
        }

        [Test]
        public void InsertManyShouldWorkCorrect()
        {
            for (var i = 0; i < 100; ++i)
            {
                hashTable.Insert(i.ToString());
            }

            for (var i = 0; i < 100; ++i)
            {
                Assert.IsTrue(hashTable.ContainsValue(i.ToString()));
            }
        }

        [Test]
        public void ChangeFunctionShouldWorkCorrect()
        {
            for (var i = 0; i < 100; ++i)
            {
                hashTable.Insert(i.ToString());
            }

            hashTable.ChangeHashFunction(new StandardHashFunction());

            for (var i = 0; i < 100; ++i)
            {
                Assert.IsTrue(hashTable.ContainsValue(i.ToString()));
            }
        }
    }
}