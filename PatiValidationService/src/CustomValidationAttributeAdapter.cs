using Pati.Validation.Core;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

namespace Pati.Validation.Service
{
    /// <summary>
    /// Adapter to provide localization to CustomValidationAttribute derived validators.
    /// </summary>
    public class CustomValidationAttributeAdapter: AttributeAdapterBase<CustomValidationAttribute>
    {
        public CustomValidationAttributeAdapter(CustomValidationAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer) { }

        public override void AddValidation(ClientModelValidationContext context) { }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName());
        }
    }
}
