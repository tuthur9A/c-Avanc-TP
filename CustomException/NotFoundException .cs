using System;

namespace TP.CustomException
{
    /// <summary>
    /// Exception type for not found exceptions
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public NotFoundException()
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message"></param>
        public NotFoundException(string message)
            : base(message)
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}