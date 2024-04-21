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
        private readonly bool _sendValProblems;
        
        /// <summary>
        /// Constructor for validate model attribute.
        /// </summary>
        /// <param name="sendValProblems">Send validation problems in ValidationProblems format.</param>
        public ValidateModelAttribute(bool sendValProblems = true)
        {
            _sendValProblems = sendValProblems;
        }
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                if (_sendValProblems)
                {
                    context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState));
                    return;
                }
                
                var errors = ValidationUtil.GetValidationErrorsFromModelState(context.ModelState);
                context.Result = new BadRequestObjectResult(errors);
            }
        }
    }
}
