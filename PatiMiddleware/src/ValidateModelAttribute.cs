using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pati.Middleware
{
    /// <summary>
    /// Attribute that checks the validation of user request and if there are errors,
    /// returns the bad request with error list.
    /// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = ValidationUtil.GetValidationErrorsFromModelState(context.ModelState);
                context.Result = new BadRequestObjectResult(errors);
            }
        }
    }
}
