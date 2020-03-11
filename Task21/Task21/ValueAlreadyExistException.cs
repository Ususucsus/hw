using System;
using System.Runtime.Serialization;

namespace Task21
{
    /// <summary>
    /// Represents exception for throw if element already exist in structure.
    /// </summary>
    [Serializable]
    public class ValueAlreadyExistException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ValueAlreadyExistException"/> class.
        /// </summary>
        public ValueAlreadyExistException()
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="ValueAlreadyExistException"/> class.
        /// </summary>
        /// <param name="message">Message of exception</param>
        public ValueAlreadyExistException(string message)
            :base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="ValueAlreadyExistException"/> class.
        /// </summary>
        /// <param name="message">Message of exception</param>
        /// <param name="inner">Inner exceptions</param>
        public ValueAlreadyExistException(string message, Exception inner)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="ValueAlreadyExistException"/> class.
        /// </summary>
        /// <param name="info">Serialization information</param>
        /// <param name="context">Streaming context</param>
        protected ValueAlreadyExistException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
