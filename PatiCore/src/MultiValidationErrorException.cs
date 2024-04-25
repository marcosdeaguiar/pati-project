using System;
using System.Collections.Generic;

namespace Pati.Core
{
    /// <summary>
    /// Throw when there are multiple validation errors in the request.
    /// </summary>
    public class MultiValidationErrorException : Exception
    {
        /// <summary>
        /// Returns the status code.
        /// </summary>
        public int Status { get; set; }

        public IDictionary<string, string[]> ValidationErrors { get; set; }

        /// <summary>
        /// Default constructor with default message.
        /// </summary>
        /// <param name="message">Message to be sent.</param>
        public MultiValidationErrorException(string message = "Bad request") : base(message)
        {
            Status = 400;
            ValidationErrors = new Dictionary<string, string[]>();
        }

        /// <summary>
        /// Constructor that receives list of validation errors.
        /// </summary>
        public MultiValidationErrorException(IDictionary<string, string[]> validationErrors, string message="Bad request") : base(message)
        {
            Status = 400;
            ValidationErrors = validationErrors;
        }
    }
}
