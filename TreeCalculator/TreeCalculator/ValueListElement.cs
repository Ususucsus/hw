namespace TreeCalculator
{
    /// <summary>
    /// Represents list element with value in it.
    /// </summary>
    public class ValueListElement : ITreeElement
    {
        /// <summary>
        /// Value of the element.
        /// </summary>
        private readonly int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueListElement"/> class.
        /// </summary>
        /// <param name="value">Value of the element</param>
        public ValueListElement(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueListElement"/> class.
        /// </summary>
        /// <param name="value">Value of the element</param>
        /// <param name="leftTreeElement">Pointer to the left son</param>
        /// <param name="rightTreeElement">Pointer to the right son</param>
        public ValueListElement(int value, ITreeElement leftTreeElement, ITreeElement rightTreeElement)
        {
            this.value = value;
            this.LeftTreeElement = leftTreeElement;
            this.RightTreeElement = rightTreeElement;
        }

        /// <summary>
        /// Gets or sets pointer to the left son.
        /// </summary>
        public ITreeElement LeftTreeElement { get; set; }

        /// <summary>
        /// Gets or sets pointer to the right son.
        /// </summary>
        public ITreeElement RightTreeElement { get; set; }

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
