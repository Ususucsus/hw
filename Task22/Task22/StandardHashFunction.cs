namespace Task22
{
    /// <summary>
    /// Represents hash function with standard c# hash.
    /// </summary>
    public class StandardHashFunction : IHashFunction
    {
        /// <summary>
        /// Returns standard c# hash code.
        /// </summary>
        /// <param name="value">Value from which hash will be calculated</param>
        /// <returns>Standard c# hash code</returns>
        public int GetHashValue(string value)
        {
            return value.GetHashCode();
        }
    }
}
