using System;

namespace Pati.Core
{
    /// <summary>
    /// Base exception class, that returns http status as well.
    /// Defaults for 500 error.
    /// </summary>
    public class ApplicationException : Exception
    {
        public int Status { get; set; }

        /// <summary>
        /// Default constructor. Should be used if error is unexpected
        /// and no other information is available.
        /// </summary>
        public ApplicationException() : base("Internal server error.")
        {
            Status = 500;
        }

        /// <summary>
        /// Customizes the message. Ideally send a localized message.
        /// </summary>
        /// <param name="message">Message to be returned to the user.</param>
        public ApplicationException(string message) : base(message)
        {
            Status = 500;
        }

        /// <summary>
        /// Constructor that customizes the message and status code.
        /// </summary>
        /// <param name="message">Message to be returned to the user.</param>
        /// <param name="status">Status code to be returned.</param>
        public ApplicationException(string message, int status) : base(message)
        {
            Status = status;
        }
    }
}
