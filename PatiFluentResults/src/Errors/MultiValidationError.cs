using FluentResults;

namespace Pati.FluentResults.Errors;

public class MultiValidationError : Error
{
    /// <summary>
    /// Returns the status code.
    /// </summary>
    public int Status { get; set; }
    
    private const string defaultErrorMessage = "One or more errors were found.";
    
    public Dictionary<string, List<string>> ValidationErrors { get; set; }

    /// <summary>
    /// Default constructor with default message.
    /// </summary>
    /// <param name="message">Message to be sent.</param>
    /// <param name="status">Status code for the error.</param>
    public MultiValidationError(string message = defaultErrorMessage, int status = 400) : base(message)
    {
        Status = status;
        ValidationErrors = new Dictionary<string, List<string>>();
    }
    
    /// <summary>
    /// Constructor that receives list of validation errors.
    /// </summary>
    /// <param name="validationErrors">Dictionary of errors.</param>
    /// <param name="message">Message for the error.</param>
    /// <param name="status">Status code for the error.</param>
    public MultiValidationError(Dictionary<string, List<string>> validationErrors,
        string message = defaultErrorMessage,
        int status = 400) : base(message)
    {
        Status = status;
        ValidationErrors = validationErrors;
    }

    public void AddValidationError(string propertyName, string errorMessage)
    {
        var errorList = ValidationErrors.GetValueOrDefault(propertyName, new List<string>());
        errorList.Add(errorMessage);
        ValidationErrors[propertyName] = errorList;
    }

    /// <summary>
    /// Returns the validation errors as dictionary of string and array of string.
    /// </summary>
    /// <returns>Dictionary with the string array in the value type.</returns>
    public IDictionary<string, string[]> ValidationErrorsAsDictionary()
    {
        var retDict = new Dictionary<string, string[]>();
        foreach (var kvPair in  ValidationErrors)
        {
            retDict.Add(kvPair.Key, kvPair.Value.ToArray());
        }
        
        return retDict;
    }
}