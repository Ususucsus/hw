namespace FunctionsOnLists.Test
{
    using System.Collections.Generic;
    using NUnit.Framework;

    public class MapTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MapShouldGiveCorrectResultOnIntegers()
        {
            CollectionAssert.AreEqual(
                new List<int>() { 2, 4, 6 }, 
                FunctionsOnLists<int, int>.Map(new List<int>() { 1, 2, 3 }, x => x * 2));
        }

        [Test]
        public void MapShouldGiveCorrectResultOnDifferentTypes()
        {
            CollectionAssert.AreEqual(
                new List<bool>() { false, true, false },
                FunctionsOnLists<string, bool>.Map(new List<string>() { "kek", "KaRaNtIn", "lol" }, x => x.Contains('a')));
        }

        [Test]
        public void MapShouldReturnEmptyListOnEmptyLists()
        {
            Assert.IsEmpty(FunctionsOnLists<string, string>.Map(new List<string>(), x => string.Empty));
            Assert.IsEmpty(FunctionsOnLists<bool, string>.Map(new List<bool>(), x => x.ToString()));
        }
    }

    public class FilterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FilterShouldWorkCorrectOnIntegers()
        {
            CollectionAssert.AreEqual(
                new List<int>() { 1, 3 },
                FunctionsOnLists<int, int>.Filter(new List<int>() { 1, 2, 3 }, x => x % 2 == 1));
        }

        [Test]
        public void FilterShouldReturnsEmptyList()
        {
            Assert.IsEmpty(FunctionsOnLists<string, string>.Filter(new List<string>() { "kek", "lol" }, x => x.Contains('a')));
            Assert.IsEmpty(FunctionsOnLists<string, string>.Filter(new List<string>(), x => true));
        }
    }

    public class FoldTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FoldShouldWorkCorrectOnSameType()
        {
            Assert.AreEqual(
                24,
                FunctionsOnLists<int, int>.Fold(
                    new List<int>() { 2, 3, 4 },
                    1, 
                    (cur, next) => cur * next));
        }

        [Test]
        public void FoldShouldWorkCorrectOnDifferentTypes()
        {
            Assert.AreEqual(
                24, 
                FunctionsOnLists<string, int>.Fold(
                    new List<string>() { "aa", "aaa", "aaaa" },
                    1, 
                    (cur, next) => cur * next.Length));
        }

        [Test]
        public void FoldShouldWorkCorrectWithEmptyList()
        {
            Assert.AreEqual(
                173,
                FunctionsOnLists<int, int>.Fold(
                    new List<int>(), 
                    173,
                    (cur, next) => 0));
        }
    }
}