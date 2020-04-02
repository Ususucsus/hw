namespace ConsoleMovements
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents exception class. Throws if save file was invalid.
    /// </summary>
    [Serializable]
    public class InvalidSaveFileException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSaveFileException"/> class.
        /// </summary>
        public InvalidSaveFileException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSaveFileException"/> class.
        /// </summary>
        /// <param name="message">Exception message</param>
        public InvalidSaveFileException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSaveFileException"/> class.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="inner">Inner exceptions</param>
        public InvalidSaveFileException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSaveFileException"/> class.
        /// </summary>
        /// <param name="info">Serialization information</param>
        /// <param name="context">Streaming context</param>
        public InvalidSaveFileException(SerializationInfo info, StreamingContext context)
        {
        }
    }
}