// <copyright file="MapTests.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace FunctionsOnLists.Test
{
    using System.Collections.Generic;
    using NUnit.Framework;

    public class MapTests
    {
        [Test]
        public void MapShouldGiveCorrectResultOnIntegers()
        {
            CollectionAssert.AreEqual(
                new List<int>() { 2, 4, 6 },
                FunctionsOnLists.Map(new List<int>() { 1, 2, 3 }, x => x * 2));
        }

        [Test]
        public void MapShouldGiveCorrectResultOnDifferentTypes()
        {
            CollectionAssert.AreEqual(
                new List<bool>() { false, true, false },
                FunctionsOnLists.Map(new List<string>() { "kek", "KaRaNtIn", "lol" }, x => x.Contains('a')));
        }

        [Test]
        public void MapShouldReturnEmptyListOnEmptyLists()
        {
            Assert.IsEmpty(FunctionsOnLists.Map(new List<string>(), x => string.Empty));
            Assert.IsEmpty(FunctionsOnLists.Map(new List<bool>(), x => x.ToString()));
        }
    }
}
