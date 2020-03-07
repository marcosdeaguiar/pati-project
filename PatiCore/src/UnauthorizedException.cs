namespace Pati.Core
{
    /// <summary>
    /// Throws when user is not authorized to access the resource.
    /// </summary>
    public class UnauthorizedException: ApplicationException
    {
        /// <summary>
        /// Default constructor with default message.
        /// </summary>
        public UnauthorizedException() : base("User not authorized.", 403) { }

        /// <summary>
        /// Constructor with custom message. Use localized message,
        /// or message customized for the resource in question.
        /// </summary>
        /// <param name="message">Custom message to the exception.</param>
        public UnauthorizedException(string message) : base(message)
        {
            Status = 403;
        }
    }
}
