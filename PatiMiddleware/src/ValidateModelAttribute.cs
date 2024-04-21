using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

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
                var svc = context.HttpContext.RequestServices;
                var probDetailsFactory = svc.GetService<ProblemDetailsFactory>();
                var valProbDetails = probDetailsFactory.CreateValidationProblemDetails(context.HttpContext, context.ModelState);
                context.Result = new BadRequestObjectResult(valProbDetails);
            }
        }
    }
}
