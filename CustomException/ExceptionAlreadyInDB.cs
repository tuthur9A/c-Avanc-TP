using System;

namespace TP.CustomException
{
    /// <summary>
    /// Exception type for Already in DB exceptions
    /// </summary>
    public class AlreadyInDBException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public AlreadyInDBException()
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message"></param>
        public AlreadyInDBException(string message)
            : base(message)
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public AlreadyInDBException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}