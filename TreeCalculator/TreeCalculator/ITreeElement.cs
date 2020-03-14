namespace TreeCalculator
{
    /// <summary>
    /// Represents element of binary tree. Provides evaluate method.
    /// </summary>
    public interface ITreeElement
    {
        /// <summary>
        /// Gets or sets pointer to the left son.
        /// </summary>
        public ITreeElement LeftTreeElement { get; set; }

        /// <summary>
        /// Gets or sets pointer to the right son.
        /// </summary>
        public ITreeElement RightTreeElement { get; set; }

        /// <summary>
        /// If element is value just returns it. If element is operation firstly evaluate value for left and right sub tree and returns result.
        /// </summary>
        /// <returns>Result of calculation in sub tree</returns>
        public int Evaluate();
    }
}
