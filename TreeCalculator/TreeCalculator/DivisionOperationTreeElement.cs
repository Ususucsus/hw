﻿// <copyright file="DivisionOperationTreeElement.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace TreeCalculator
{
    using System;

    /// <summary>
    /// Represents division operation tree element.
    /// </summary>
    public class DivisionOperationTreeElement : OperationTreeElement, ITreeElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DivisionOperationTreeElement"/> class.
        /// </summary>
        /// <param name="leftTreeElement">Pointer to the left son.</param>
        /// <param name="rightTreeElement">Pointer to the right son.</param>
        public DivisionOperationTreeElement(ITreeElement leftTreeElement, ITreeElement rightTreeElement)
            : base(leftTreeElement, rightTreeElement)
        {
        }

        /// <summary>
        /// Evaluate operation result.
        /// </summary>
        /// <returns>Operation result.</returns>
        /// <exception cref="DivideByZeroException">Result of right sub tree evaluate method is zero.</exception>
        public override int Evaluate()
        {
            if (this.RightTreeElement.Evaluate() == 0)
            {
                throw new DivideByZeroException("Result of right sub tree evaluate method is zero");
            }

            return this.LeftTreeElement.Evaluate() / this.RightTreeElement.Evaluate();
        }

        /// <summary>
        /// Returns "/" string.
        /// </summary>
        /// <returns>Division symbol string.</returns>
        public override string ToString() => "/";
    }
}