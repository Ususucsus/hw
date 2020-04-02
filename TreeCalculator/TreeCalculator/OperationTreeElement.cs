// <copyright file="OperationTreeElement.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace TreeCalculator
{
    using System;

    /// <summary>
    /// Provides abstract class for operation tree elements.
    /// </summary>
    public abstract class OperationTreeElement : ITreeElement
    {
        /// <summary>
        /// Pointer to the left son.
        /// </summary>
        private ITreeElement leftTreeElement;

        /// <summary>
        /// Pointer to the right son.
        /// </summary>
        private ITreeElement rightTreeElement;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationTreeElement"/> class.
        /// </summary>
        /// <param name="leftTreeElement">Pointer to the left son.</param>
        /// <param name="rightTreeElement">Pointer to the right son.</param>
        protected OperationTreeElement(ITreeElement leftTreeElement, ITreeElement rightTreeElement)
        {
            this.LeftTreeElement = leftTreeElement ?? throw new ArgumentNullException(nameof(leftTreeElement));
            this.RightTreeElement = rightTreeElement ?? throw new ArgumentNullException(nameof(rightTreeElement));
        }

        /// <summary>
        /// Gets or sets pointer to the left son.
        /// </summary>
        /// <exception cref="ArgumentNullException">Attempt to set empty sub tree.</exception>
        public ITreeElement LeftTreeElement
        {
            get => this.leftTreeElement;
            set => this.leftTreeElement = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets or sets pointer to the right son.
        /// <exception cref="ArgumentNullException">Attempt to set empty sub tree.</exception>
        /// </summary>
        public ITreeElement RightTreeElement
        {
            get => this.rightTreeElement;
            set => this.rightTreeElement = value ?? throw new ArgumentNullException(nameof(value));
        }
        
        /// <summary>
        /// Returns result of operation.
        /// </summary>
        /// <returns>Result of operation.</returns>
        public abstract int Evaluate();
    }
}