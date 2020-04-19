// <copyright file="ITreeElement.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace TreeCalculator
{
    /// <summary>
    /// Represents element of binary tree. Provides evaluate method.
    /// </summary>
    public interface ITreeElement
    {
        /// <summary>
        /// If element is value just returns it. If element is operation firstly evaluate value for left and right sub tree and returns result.
        /// </summary>
        /// <returns>Result of calculation in sub tree.</returns>
        int Evaluate();
    }
}
