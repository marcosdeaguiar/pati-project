namespace Pati.FluentResults.Errors;

/// <summary>
/// Error when the user sends a invalid request.
/// </summary>
public class BadRequestError : ApplicationError
{
    /// <summary>
    /// Default constructor with default message.
    /// </summary>
    public BadRequestError() : base("Bad request.", 400) { }

    /// <summary>
    /// Constructor with custom message. Use localized message,
    /// or message customized for the resource in question.
    /// </summary>
    /// <param name="message">Custom message to the error.</param>
    /// <param name="status">Status to the error.</param>
    public BadRequestError(string message, int status = 400) : base(message, status) { }
}