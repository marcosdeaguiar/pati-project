using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace Pati.Validation.Service
{
    /// <summary>
    /// The provider for the CustomValidationAttributeAdapter.
    /// </summary>
    public class CustomValidationAttributeAdapterProvider: IValidationAttributeAdapterProvider
    {
        private readonly IValidationAttributeAdapterProvider _baseProvider = new ValidationAttributeAdapterProvider();

        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            if (attribute is Pati.Validation.Core.CustomValidationAttribute)
                return new CustomValidationAttributeAdapter(attribute as Pati.Validation.Core.CustomValidationAttribute, stringLocalizer);
            else
                return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
