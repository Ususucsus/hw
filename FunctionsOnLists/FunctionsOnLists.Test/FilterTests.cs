// <copyright file="FilterTests.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace FunctionsOnLists.Test
{
    using System.Collections.Generic;
    using NUnit.Framework;

    public class FilterTests
    {
        [Test]
        public void FilterShouldWorkCorrectOnIntegers()
        {
            CollectionAssert.AreEqual(
                new List<int>() { 1, 3 },
                FunctionsOnLists.Filter(new List<int>() { 1, 2, 3 }, x => x % 2 == 1));
        }

        [Test]
        public void FilterShouldReturnsEmptyList()
        {
            Assert.IsEmpty(FunctionsOnLists.Filter(new List<string>() { "kek", "lol" }, x => x.Contains('a')));
            Assert.IsEmpty(FunctionsOnLists.Filter(new List<string>(), x => true));
        }
    }
}