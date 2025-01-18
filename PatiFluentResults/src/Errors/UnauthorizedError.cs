namespace Pati.FluentResults.Errors;

/// <summary>
/// Error for when user is not authorized to do the operation.
/// </summary>
public class UnauthorizedError : ApplicationError
{
    /// <summary>
    /// Default constructor with default message.
    /// </summary>
    public UnauthorizedError() : base("User not authorized.", 403) { }

    /// <summary>
    /// Constructor with custom message. Use localized message,
    /// or message customized for the resource in question.
    /// </summary>
    /// <param name="message">Custom message to the error.</param>
    /// <param name="status">Status code for the error.</param>
    public UnauthorizedError(string message, int status = 403) : base(message, status) { }
}