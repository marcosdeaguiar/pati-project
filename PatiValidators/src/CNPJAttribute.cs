using System;
using System.ComponentModel.DataAnnotations;

namespace Pati.Validators
{
    /// <summary>
    /// Validation attribute to use to validate brazilian CPF format and check digits.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property, AllowMultiple = false)]
    public class CNPJAttribute: Pati.Validation.Core.CustomValidationAttribute
    {
        public CNPJAttribute() { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cnpj;

            try
            {
                cnpj = (string)value;
            }
            catch (Exception)
            {
                return new ValidationResult(GetErrorMessage(validationContext));
            }

            if (!ValidationUtils.IsCNPJValid(cnpj))
            {
                return new ValidationResult(GetErrorMessage(validationContext));
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(ErrorMessage))
            {
                return "Invalid CNPJ";
            }

            return FormatErrorMessage(ErrorMessageString);
        }
    }
}
