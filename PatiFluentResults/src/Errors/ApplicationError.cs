using FluentResults;

namespace Pati.FluentResults.Errors;

/// <summary>
///  Generic application error.
/// </summary>
public class ApplicationError : Error
{
    public int Status { get; set; }

    /// <summary>
    /// Default constructor. Should be used if error is unexpected
    /// and no other information is available.
    /// </summary>
    public ApplicationError(int status = 500) : base("Internal server error.")
    {
        Status = status;
    }
    
    /// <summary>
    /// Constructor that customizes the message and status code.
    /// </summary>
    /// <param name="message">Message to be returned to the user.</param>
    /// <param name="status">Status code to be returned.</param>
    public ApplicationError(string message, int status = 500) : base(message)
    {
        Status = status;
    }
}