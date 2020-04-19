// <copyright file="ListTests.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using System;
using NUnit.Framework;

namespace Task21.Test
{
    public class ListTests
    {
        private List list;
        private List arrayList;

        [SetUp]
        public void Setup()
        {
            list = new List();
            arrayList = new List(new int[] { 1, 2 });
        }

        [Test]
        public void NewListShouldBeEmpty()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void InitializedListWithArrayShouldNotBeEmpty()
        {
            Assert.IsFalse(arrayList.IsEmpty());
        }

        [Test]
        public void LengthOfInitializedListShouldBeCorrect()
        {
            Assert.AreEqual(2, arrayList.Length());
        }

        [Test]
        public void LengthOfNewListShouldBeZero()
        {
            Assert.AreEqual(0, list.Length());
        }

        [Test]
        public void GetValueWithinLimitsShouldReturnCorrectValue()
        {
            Assert.AreEqual(2, arrayList.GetValue(1));
        }

        [Test]
        public void GetValueBeyondLimitsShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.GetValue(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.GetValue(2));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.GetValue(0));
        }

        [Test]
        public void RemoveFirstElementShouldWorkCorrect()
        {
            var lengthBeforeRemove = arrayList.Length();
            arrayList.Remove(0);

            Assert.AreEqual(lengthBeforeRemove - 1, arrayList.Length());
            Assert.AreEqual(2, arrayList.GetValue(0));
        }

        [Test]
        public void RemoveAnyElementShouldWorkCorrect()
        {
            var lengthBeforeRemove = arrayList.Length();
            arrayList.Remove(1);

            Assert.AreEqual(lengthBeforeRemove - 1, arrayList.Length());
            Assert.AreEqual(1, arrayList.GetValue(0));
        }


        [Test]
        public void RemoveBeyondLimitsShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.Remove(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.Remove(2));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Remove(0));
        }

        [Test]
        public void InsertShouldInsertElementToList()
        {
            var lengthBeforeInsert = arrayList.Length();
            arrayList.Insert(1, 3);

            Assert.AreEqual(lengthBeforeInsert + 1, arrayList.Length());
            Assert.AreEqual(2, arrayList.GetValue(2));
            Assert.AreEqual(3, arrayList.GetValue(1));
        }

        [Test]
        public void InsertAtFirstPositionShouldWorkCorrect()
        {
            var lengthBeforeInsert = arrayList.Length();
            arrayList.Insert(0, 3);

            Assert.AreEqual(lengthBeforeInsert + 1, arrayList.Length());
            Assert.AreEqual(1, arrayList.GetValue(1));
            Assert.AreEqual(3, arrayList.GetValue(0));
        }

        [Test]
        public void InsertBeyondLimitsShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.Insert(-1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.Insert(3, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(1, 0));
        }

        [Test]
        public void ListShouldBeEmptyAfterRemoveAllElements()
        {
            arrayList.Remove(0);
            arrayList.Remove(0);

            Assert.IsTrue(arrayList.IsEmpty());
        }

        [Test]
        public void ListInitializedWithEmptyArrayShouldBeEmpty()
        {
            var newList = new List(new int[] { });

            Assert.IsTrue(newList.IsEmpty());
        }

        [Test]
        public void EmptyListToString()
        {
            Assert.AreEqual("List: ", list.ToString());
        }

        [Test]
        public void ListToString()
        {
            Assert.AreEqual("List: 1, 2", arrayList.ToString());
        }

        [Test]
        public void ContainsValueOnEmptyListShouldWorkCorrect()
        {
            Assert.IsFalse(list.ContainsValue(5));
        }

        [Test]
        public void ContainsValueAfterInsertShouldWorkCorrect()
        {
            list.Insert(0, 5);

            Assert.IsTrue(list.ContainsValue(5));
            Assert.IsFalse(list.ContainsValue(4));
        }

        [Test]
        public void ContainsValueAfterRemoveShouldWorkCorrect()
        {
            arrayList.Remove(0);

            Assert.IsTrue(arrayList.ContainsValue(2));
            Assert.IsFalse(arrayList.ContainsValue(1));

            arrayList.Remove(0);

            Assert.IsFalse(arrayList.ContainsValue(2));
        }
    }
}