namespace Pati.Core
{
    /// <summary>
    /// Thrown when user sends a invalid or bad formated request.
    /// </summary>
    public class BadRequestException: ApplicationException
    {
        /// <summary>
        /// Default constructor with default message.
        /// </summary>
        public BadRequestException() : base("Bad request.", 400) { }

        /// <summary>
        /// Constructor with custom message. Use localized message,
        /// or message customized for the resource in question.
        /// </summary>
        /// <param name="message">Custom message to the exception.</param>
        public BadRequestException(string message) : base(message)
        {
            Status = 400;
        }
    }
}
