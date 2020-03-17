using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using Pati.Core;

namespace Pati.Middleware
{
    /// <summary>
    /// Class that has utilities methods to help with validation.
    /// </summary>
    public class ValidationUtil
    {
        /// <summary>
        /// Functions that receives a model state and returns a list of
        /// validation errors to be displayed to the user.
        /// </summary>
        /// <param name="modelState">The model state with the validation errors.</param>
        /// <returns>List of validation errors to be returned to the user.</returns>
        public static IEnumerable<ValidationError> GetValidationErrorsFromModelState(ModelStateDictionary modelState)
        {
            var validationErrors = new List<ValidationError>();

            foreach (var entry in modelState)
            {
                if (entry.Value.Errors.Count == 0)
                {
                    continue;
                }

                validationErrors.Add(new ValidationError
                {
                    FieldName = entry.Key,
                    ErrorMessage = entry.Value.Errors.FirstOrDefault().ErrorMessage
                });
            }

            return validationErrors;
        }
    }
}
