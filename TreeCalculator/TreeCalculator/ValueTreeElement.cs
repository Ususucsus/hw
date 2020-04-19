// <copyright file="ValueTreeElement.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace TreeCalculator
{
    using System;

    /// <summary>
    /// Represents list element with value in it.
    /// </summary>
    public class ValueTreeElement : ITreeElement
    {
        /// <summary>
        /// Value of the element.
        /// </summary>
        private readonly int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueTreeElement"/> class.
        /// </summary>
        /// <param name="value">Value of the element.</param>
        public ValueTreeElement(int value)
            => this.value = value;

        /// <summary>
        /// Returns value of the element.
        /// </summary>
        /// <returns>Value of the element.</returns>
        public int Evaluate() 
            => this.value;

        /// <summary>
        /// Returns string with value of the element.
        /// </summary>
        /// <returns>Value of the element.</returns>
        public override string ToString() 
            => this.value.ToString();
    }
}
