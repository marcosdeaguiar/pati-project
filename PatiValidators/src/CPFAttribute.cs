using System;
using System.ComponentModel.DataAnnotations;

namespace Pati.Validators
{
    /// <summary>
    /// Validation attribute to use to validate brazilian CPF format and check digits.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property, AllowMultiple = false)]
    public class CPFAttribute : Pati.Validation.Core.CustomValidationAttribute
    {
        public CPFAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cpf;

            try
            {
                cpf = (string)value;
            }
            catch (Exception)
            {
                return new ValidationResult(GetErrorMessage(validationContext));
            }

            int[] cpfArray = StringUtil.ToIntArray(cpf);

            if (!ValidationUtils.IsCPFValid(cpf))
            {
                return new ValidationResult(GetErrorMessage(validationContext));
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(ErrorMessage))
            {
                return "Invalid CPF";
            }

            return FormatErrorMessage(ErrorMessageString);
        }
    }
}
