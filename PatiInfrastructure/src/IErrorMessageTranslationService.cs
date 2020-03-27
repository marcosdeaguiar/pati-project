namespace Pati.Infrastructure
{
    /// <summary>
    /// Interface for Error message translation service implementations.
    /// </summary>
    public interface IErrorMessageTranslationService
    {
        /// <summary>
        /// Get localized error message based on the string key.
        /// </summary>
        /// <param name="errorKey">The key to recover the message.</param>
        /// <returns>Localized message.</returns>
        string GetLocalizedError(string errorKey);

        /// <summary>
        /// Get localized message based on the error code.
        /// </summary>
        /// <param name="statusCode">Status code to recover the localized string.</param>
        /// <returns>Localized message.</returns>
        string GetMessageFromStatusCode(int statusCode);
    }
}
