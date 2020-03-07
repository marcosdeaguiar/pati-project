using System.ComponentModel.DataAnnotations;

namespace Pati.Validation.Core
{
    /// <summary>
    /// Base class to be extended when creating validation attribute. So it can be used in the adapter
    /// for localization (i18n).
    /// </summary>
    public class CustomValidationAttribute: ValidationAttribute
    {
    }
}
