using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Pati.Infrastructure;

namespace Pati.Middleware
{
    /// <summary>
    /// Middleware that should be put before the SPA middleware to return 404 on api calls.
    /// </summary>
    public static class Api404Middleware
    {
        /// <summary>
        /// Extension method to enable the middleware.
        /// </summary>
        /// <param name="app">Application builder instance.</param>
        /// <param name="errorMsgSvc">The implementation of the IErrorMessageTranslationService. If null returns default english message.
        /// The implementation must have a return string for 404 code.</param>
        /// <param name="startSegment">The start segment for api calls.</param>
        public static void UseApi404Middleware(this IApplicationBuilder app, IErrorMessageTranslationService errorMsgSvc, string startSegment = "/api")
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments(startSegment))
                {
                    string errorMsg = "Resource not found.";
                    context.Response.StatusCode = 404;
                    if (errorMsgSvc != null)
                    {
                        errorMsg = errorMsgSvc.GetMessageFromStatusCode(404);
                    }
                    await context.Response.WriteAsync(errorMsg);
                    return;
                }

                await next();
            });
        }
    }
}
