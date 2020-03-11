namespace Task22
{
    /// <summary>
    /// Represents hash function with hash as length of string
    /// </summary>
    public class LengthHashFunction : IHashFunction
    {
        /// <summary>
        /// Returns hash as value length.
        /// </summary>
        /// <param name="value">Value from which hash will be calculated</param>
        /// <returns>hash as value length.</returns>
        public int GetHashValue(string value)
        {
            return value.Length;
        }
    }
}