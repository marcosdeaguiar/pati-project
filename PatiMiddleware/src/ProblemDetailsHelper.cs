using Microsoft.AspNetCore.Mvc;

namespace Pati.Middleware;

public class ProblemDetailsHelper
{
    public static ProblemDetails CreateProblemDetails(int status, string detailsMessage)
    {
        var problemDetails = new ProblemDetails();
        problemDetails.Detail = detailsMessage;
        problemDetails.Status = status;

        switch (status)
        {
            case 400:
                problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
                problemDetails.Title = "Bad Request";
                break;
            case 401:
                problemDetails.Type = "https://tools.ietf.org/html/rfc7235#section-3.1";
                problemDetails.Title = "Unauthorized";
                break;
            case 403:
                problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3";
                problemDetails.Title = "Forbidden";
                break;
            case 404:
                problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4";
                problemDetails.Title = "Not Found";
                break;
            case 500:
                problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1";
                problemDetails.Title = "Internal Server Error";
                break;
            default:
                problemDetails.Type = "Unknown Error";
                problemDetails.Title = "Unknown Error";
                break;
        }
        
        return problemDetails;
    }
}