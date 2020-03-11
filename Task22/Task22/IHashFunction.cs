namespace Task22
{
    /// <summary>
    /// Represents interface for hash functions.
    /// </summary>
    public interface IHashFunction
    {
        /// <summary>
        /// Returns hash function from value.
        /// </summary>
        /// <param name="value">Value from which hash function will be calculated</param>
        /// <returns>Hash value</returns>
        public int GetHashValue(string value);
    }
}