using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Pati.Middleware
{
    /// <summary>
    /// Action filter that trim all the strings submited in the request body
    /// or query when mapped to input object.
    /// </summary>
    public class TrimInputStringsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var arg in context.ActionArguments)
            {
                if (arg.Value is string)
                {
                    if (arg.Value == null)
                    {
                        continue;
                    }

                    string val = arg.Value as string;
                    if (!string.IsNullOrEmpty(val))
                    {
                        context.ActionArguments[arg.Key] = val.Trim();
                    }

                    continue;
                }

                Type argType = arg.Value.GetType();
                if (!argType.IsClass)
                {
                    continue;
                }

                TrimAllStringsInObject(arg.Value, argType);
            }
        }

        private void TrimAllStringsInObject(object arg, Type argType)
        {
            var stringProperties = argType.GetProperties()
                                          .Where(p => p.PropertyType == typeof(string));

            foreach (var stringProperty in stringProperties)
            {
                string currentValue = stringProperty.GetValue(arg, null) as string;
                if (!string.IsNullOrEmpty(currentValue))
                {
                    stringProperty.SetValue(arg, currentValue.Trim(), null);
                }
            }
        }
    }
}
