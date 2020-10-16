using System;

namespace TP.CustomException
{
    /// <summary>
    /// Exception type for Bad Request exceptions
    /// </summary>
    public class BadRequestException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public BadRequestException()
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message"></param>
        public BadRequestException(string message)
            : base(message)
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}