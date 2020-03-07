namespace Pati.Core
{
    /// <summary>
    /// Throw when users request is not authenticated (and authentication is required).
    /// </summary>
    public class UnauthenticatedException: ApplicationException
    {
        /// <summary>
        /// Default constructor with default message.
        /// </summary>
        public UnauthenticatedException() : base("User not authenticated.", 401) { }

        /// <summary>
        /// Constructor with custom message. Use localized message,
        /// or message customized for the resource in question.
        /// </summary>
        /// <param name="message">Custom message to the exception.</param>
        public UnauthenticatedException(string message) : base(message)
        {
            Status = 401;
        }
    }
}
