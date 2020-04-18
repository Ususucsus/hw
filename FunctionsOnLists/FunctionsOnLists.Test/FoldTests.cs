// <copyright file="FoldTests.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace FunctionsOnLists.Test
{
    using System.Collections.Generic;
    using NUnit.Framework;

    public class FoldTests
    {
        [Test]
        public void FoldShouldWorkCorrectOnSameType()
        {
            Assert.AreEqual(24, FunctionsOnLists.Fold(new List<int>() { 2, 3, 4 }, 1, (cur, next) => cur * next));
        }

        [Test]
        public void FoldShouldWorkCorrectOnDifferentTypes()
        {
            Assert.AreEqual(24, FunctionsOnLists.Fold(new List<string>() { "aa", "aaa", "aaaa" }, 1, (cur, next) => cur * next.Length));
        }

        [Test]
        public void FoldShouldWorkCorrectWithEmptyList()
        {
            Assert.AreEqual(173, FunctionsOnLists.Fold(new List<int>(), 173, (cur, next) => 0));
        }
    }
}