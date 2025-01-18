namespace Pati.FluentResults.Errors;

/// <summary>
/// Returned when there is a conflict error in the application.
/// </summary>
public class ConflictError : ApplicationError
{
    /// <summary>
    /// Default constructor with default message.
    /// </summary>
    public ConflictError() : base("Conflict.", 409) { }

    /// <summary>
    /// Constructor with custom message. Use localized message,
    /// or message customized for the resource in question.
    /// </summary>
    /// <param name="message">Custom message to the error.</param>
    /// <param name="status">Status code to the error.</param>
    public ConflictError(string message, int status = 409) : base(message, status) { }
}