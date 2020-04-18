// <copyright file="LengthHashFunction.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Task22
{
    /// <summary>
    /// Represents hash function with hash as length of string.
    /// </summary>
    public class LengthHashFunction : IHashFunction
    {
        /// <summary>
        /// Returns hash as value length.
        /// </summary>
        /// <param name="value">Value from which hash will be calculated.</param>
        /// <returns>Hash as value length.</returns>
        public int GetHashValue(string value) 
            => value.Length;
    }
}