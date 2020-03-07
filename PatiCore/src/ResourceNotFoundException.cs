namespace Pati.Core
{
    /// <summary>
    /// Exception to be thrown when requested resource is not found.
    /// </summary>
    public class ResourceNotFoundException: ApplicationException
    {
        /// <summary>
        /// Default constructor with default message.
        /// </summary>
        public ResourceNotFoundException(): base("Resource not found.", 404) { }

        /// <summary>
        /// Constructor with custom message. Use localized message,
        /// or message customized for the resource in question.
        /// </summary>
        /// <param name="message">Custom message to the exception.</param>
        public ResourceNotFoundException(string message) : base(message)
        {
            Status = 404;
        }
    }
}
