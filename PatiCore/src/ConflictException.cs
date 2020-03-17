namespace Pati.Core
{
    /// <summary>
    /// Thrown when there is a conflict error in the application.
    /// </summary>
    public class ConflictException: ApplicationException
    {
        /// <summary>
        /// Default constructor with default message.
        /// </summary>
        public ConflictException() : base("Conflict.", 409) { }

        /// <summary>
        /// Constructor with custom message. Use localized message,
        /// or message customized for the resource in question.
        /// </summary>
        /// <param name="message">Custom message to the exception.</param>
        public ConflictException(string message) : base(message)
        {
            Status = 409;
        }
    }
}
