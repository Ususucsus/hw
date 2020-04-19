// <copyright file="EvaluatorTests.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace TreeCalculator.Test
{
    using System;
    using NUnit.Framework;

    public class EvaluatorTests
    {
        private Evaluator evaluator;

        [SetUp]
        public void Setup()
        {
            evaluator = new Evaluator();
        }

        [Test]
        [TestCase("(* 2 5)", ExpectedResult = 10)]
        [TestCase("(+ 1 1)", ExpectedResult = 2)]
        [TestCase("(- 0 -10)", ExpectedResult = 10)]
        [TestCase("(/ 2 5)", ExpectedResult = 0)]
        public int SimpleEvaluatorShouldGiveCorrectAnswer(string expression)
            => evaluator.EvaluateExpression(expression);

        [Test]
        [TestCase("(* (+ 2 2) 5)", ExpectedResult = 20)]
        [TestCase("(* 5 (+ 2 2))", ExpectedResult = 20)]
        [TestCase("(- (* (+ 2 2) 5) 20)", ExpectedResult = 0)]
        [TestCase("(+ (+ 2 2) (+ 2 2))", ExpectedResult = 8)]
        [TestCase("(/ (* 100 0) 10000)", ExpectedResult = 0)]
        public int EvaluatorShouldGiveCorrectAnswer(string expression) 
            => evaluator.EvaluateExpression(expression);

        [Test]
        [TestCase("")]
        [TestCase("(")]
        [TestCase("()")]
        [TestCase("(1)")]
        [TestCase("abc")]
        [TestCase("(abc 5 5)")]
        [TestCase("(5 55 5)")]
        [TestCase("(+ (+ 5 5) (+ 5))")]
        [TestCase("(+ () ())")]
        [TestCase("(+ + 5)")]
        [TestCase("+ 2 + +) 5")]
        [TestCase("+ 5 5abc")]
        public void EvaluatorShouldThrowException(string expression)
        {
            Assert.Throws<InvalidOperationException>(() => evaluator.EvaluateExpression(expression));
        }

        [Test]
        public void EvaluatorShouldThrowExceptionWhenNull()
        {
            Assert.Throws<ArgumentNullException>(() => evaluator.EvaluateExpression(null));
        }
    }
}