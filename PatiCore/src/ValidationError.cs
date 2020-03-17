using System;
using System.Collections.Generic;
using System.Text;

namespace Pati.Core
{
    /// <summary>
    /// Class that represents validation errors that will be sent back to the user.
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// The name of the field that is invalid (i.e. name of a form field).
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Error message to be presented to the user.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
