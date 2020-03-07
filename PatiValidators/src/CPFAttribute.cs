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


            if (string.IsNullOrEmpty(cpf) || cpf.Length != 11 || !StringUtil.IsDigitsOnly(cpf))
            {
                return new ValidationResult(GetErrorMessage(validationContext));
            }

            int[] cpfArray = StringUtil.ToIntArray(cpf);

            if (!IsCPFValid(cpfArray))
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

        private bool IsCPFValid(int[] cpfArray)
        {
            int sum = 0;
            int multi = 10;

            for (int i = 0; i < 9; i++)
            {
                sum += multi * cpfArray[i];
                multi--;
            }

            int digit = (sum * 10) % 11;

            if (digit == 10)
            {
                digit = 0;
            }

            if (digit != cpfArray[9])
            {
                return false;
            }

            multi = 11;
            sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += multi * cpfArray[i];
                multi--;
            }

            digit = (sum * 10) % 11;

            if (digit == 10)
            {
                digit = 0;
            }

            if (digit != cpfArray[10])
            {
                return false;
            }

            return true;
        }

    }
}
