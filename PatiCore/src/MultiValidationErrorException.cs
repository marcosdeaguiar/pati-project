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

        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        /// <summary>
        /// Default constructor with default message.
        /// </summary>
        public MultiValidationErrorException() : base("Bad request.")
        {
            Status = 400;
        }

        /// <summary>
        /// Constructor that receives list of validation errors.
        /// </summary>
        public MultiValidationErrorException(IEnumerable<ValidationError> validationErrors) : base("Bad request.")
        {
            Status = 400;
            ValidationErrors = validationErrors;
        }
    }
}
