namespace TreeCalculator
{
    using System;

    /// <summary>
    /// Represents addition operation tree element.
    /// </summary>
    public class AdditionOperationTreeElement : OperationTreeElement, ITreeElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionOperationTreeElement"/> class.
        /// </summary>
        /// <param name="leftTreeElement">Pointer to the left son</param>
        /// <param name="rightTreeElement">Pointer to the right son</param>
        public AdditionOperationTreeElement(ITreeElement leftTreeElement, ITreeElement rightTreeElement)
            : base(leftTreeElement, rightTreeElement)
        {
        }

        /// <summary>
        /// Evaluate operation result.
        /// </summary>
        /// <returns>Operation result</returns>
        public override int Evaluate()
        {
            return this.LeftTreeElement.Evaluate() + this.RightTreeElement.Evaluate();
        }

        /// <summary>
        /// Returns "+" string.
        /// </summary>
        /// <returns>"+" string</returns>
        public override string ToString()
        {
            return "+";
        }
    }
}