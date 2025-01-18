namespace Pati.FluentResults.Errors;

/// <summary>
/// Error when the user is not authenticated.
/// </summary>
public class UnauthenticatedError : ApplicationError
{
    /// <summary>
    /// Default constructor with default message.
    /// </summary>
    public UnauthenticatedError() : base("User not authenticated.", 401) { }

    /// <summary>
    /// Constructor with custom message. Use localized message,
    /// or message customized for the resource in question.
    /// </summary>
    /// <param name="message">Custom message to the error.</param>
    /// <param name="status">Status code to the error.</param>
    public UnauthenticatedError(string message, int status = 401) : base(message, status) { }
}