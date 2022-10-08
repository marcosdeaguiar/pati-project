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


            if (string.IsNullOrEmpty(cnpj) || cnpj.Length != 14 || !StringUtil.IsDigitsOnly(cnpj))
            {
                return new ValidationResult(GetErrorMessage(validationContext));
            }

            int[] cnpjArray = StringUtil.ToIntArray(cnpj);

            if (!IsCNPJValid(cnpjArray))
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

        private bool IsCNPJValid(int[] cnpjArray)
        {
            int sum = 0;
            int firstDigit = 0;
            int secondDigit = 0;
            bool allTheSame = true;
            int[] multiArray1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiArray2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int firstVal = cnpjArray[0];


            for (int i = 0; i < 12; i++)
            {
                sum += multiArray1[i] * cnpjArray[i];
                
                if (allTheSame && cnpjArray[i] != firstVal) { allTheSame = false; }
            }

            if (allTheSame)
            {
                return false;
            }

            int sumMod = sum % 11;
            if (sumMod > 1)
            {
                firstDigit = 11 - sumMod;
            }            

            if (firstDigit != cnpjArray[12])
            {
                return false;
            }

            sum = 0;

            for (int i = 0; i < 13; i++)
            {
                sum += multiArray2[i] * cnpjArray[i];
            }

            sumMod = sum % 11;

            if (sumMod > 1)
            {
                secondDigit = 11 - sumMod;
            }

            if (secondDigit != cnpjArray[13])
            {
                return false;
            }

            return true;
        }
    }
}
