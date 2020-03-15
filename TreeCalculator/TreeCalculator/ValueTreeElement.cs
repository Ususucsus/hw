using System;

namespace TreeCalculator
{
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
        /// <param name="value">Value of the element</param>
        public ValueTreeElement(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets or sets pointer to the left son.
        /// </summary>
        /// <exception cref="InvalidOperationException">Attempt to set something to left subtree</exception>
        public ITreeElement LeftTreeElement
        {
            get => null;
            set => throw new InvalidOperationException("Value element could not contain sub trees");
        }

        /// <summary>
        /// Gets or sets pointer to the right son.
        /// </summary>
        /// <exception cref="InvalidOperationException">Attempt to set something to right subtree</exception>
        public ITreeElement RightTreeElement
        {
            get => null;
            set => throw new InvalidOperationException("Value element could not contain sub trees");
        }

        /// <summary>
        /// Returns value of the element
        /// </summary>
        /// <returns>value of the element</returns>
        public int Evaluate()
        {
            return this.value;
        }

        /// <summary>
        /// Returns string with value of the element
        /// </summary>
        /// <returns>value of the element</returns>
        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
