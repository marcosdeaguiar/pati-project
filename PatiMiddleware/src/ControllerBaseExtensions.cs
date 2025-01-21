using System.Collections.Generic;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pati.FluentResults.Errors;

namespace Pati.Middleware;

public static class ControllerBaseExtensions
{
    private static ModelStateDictionary ConvertErrorsDictionaryToModelState(Dictionary<string, List<string>> errors)
    {
        var modelStateDict = new ModelStateDictionary();
        foreach (var kvPair in errors)
        {                  
            foreach(var errorMessage in kvPair.Value)
            {
                modelStateDict.AddModelError(kvPair.Key, errorMessage);
            }
        }
        
        return modelStateDict;
    }
    
    public static IActionResult HandleError(this ControllerBase controller, Error error)
    {
        return error switch
        {
            ApplicationError appError => controller.Problem(
                statusCode: appError.Status,
                detail: appError.Message),
            MultiValidationError multiError => controller.ValidationProblem(
                statusCode: multiError.Status,
                modelStateDictionary: ConvertErrorsDictionaryToModelState(multiError.ValidationErrors)),
            _ => controller.Problem(
                statusCode: StatusCodes.Status500InternalServerError)
        };
    }
}