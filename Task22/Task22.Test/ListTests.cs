using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;


namespace Task22.Test
{
    public class ListTests
    {
        private List list;
        private List arrayList;

        [SetUp]
        public void Setup()
        {
            list = new List();
            arrayList = new List(new string[] { "kek", "lol"});
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
            Assert.AreEqual(arrayList.Length(), 2);
        }

        [Test]
        public void LengthOfNewListShouldBeZero()
        {
            Assert.AreEqual(list.Length(), 0);
        }

        [Test]
        public void GetValueWithinLimitsShouldReturnCorrectValue()
        {
            Assert.AreEqual(arrayList.GetValue(1), "lol");
        }

        [Test]
        public void GetValueBeyondLimitsShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.GetValue(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.GetValue(2));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.GetValue(0));
        }

        [Test]
        public void SetValueShouldChangeElementValue()
        {
            arrayList.SetValue(0, "ne kek");

            Assert.AreEqual(arrayList.GetValue(0), "ne kek");
        }

        [Test]
        public void SetValueBeyondLimitsShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.SetValue(-1, "hz"));
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.SetValue(2, "hz"));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.SetValue(-1, "hz"));
        }

        [Test]
        public void RemoveFirstElementShouldWorkCorrect()
        {
            var lengthBeforeRemove = arrayList.Length();
            arrayList.Remove(0);

            Assert.AreEqual(arrayList.Length(), lengthBeforeRemove - 1);
            Assert.AreEqual(arrayList.GetValue(0), "lol");
        }

        [Test]
        public void RemoveAnyElementShouldWorkCorrect()
        {
            var lengthBeforeRemove = arrayList.Length();
            arrayList.Remove(1);

            Assert.AreEqual(arrayList.Length(), lengthBeforeRemove - 1);
            Assert.AreEqual(arrayList.GetValue(0), "kek");
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
            arrayList.Insert(1, "mem");

            Assert.AreEqual(arrayList.Length(), lengthBeforeInsert + 1);
            Assert.AreEqual(arrayList.GetValue(2), "lol");
            Assert.AreEqual(arrayList.GetValue(1), "mem");
        }

        [Test]
        public void InsertAtFirstPositionShouldWorkCorrect()
        {
            var lengthBeforeInsert = arrayList.Length();
            arrayList.Insert(0, "mem");

            Assert.AreEqual(arrayList.Length(), lengthBeforeInsert + 1);
            Assert.AreEqual(arrayList.GetValue(1), "kek");
            Assert.AreEqual(arrayList.GetValue(0), "mem");
        }

        [Test]
        public void InsertBeyondLimitsShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.Insert(-1, "hz"));
            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.Insert(3, "hz"));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(1, "hz"));
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
            var newList = new List(new string[] { });

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
            Assert.AreEqual("List: kek, lol", arrayList.ToString());
        }
    }
}