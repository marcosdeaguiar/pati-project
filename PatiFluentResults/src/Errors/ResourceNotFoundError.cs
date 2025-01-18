namespace Pati.FluentResults.Errors;

public class ResourceNotFoundError : ApplicationError
{
    /// <summary>
    /// Default constructor with default message.
    /// </summary>
    public ResourceNotFoundError(): base("Resource not found.", 404) { }

    /// <summary>
    /// Constructor with custom message. Use localized message,
    /// or message customized for the resource in question.
    /// </summary>
    /// <param name="message">Custom message to the error.</param>
    /// <param name="status">Status code to the error.</param>
    public ResourceNotFoundError(string message, int status = 404) : base(message, status) { }
}