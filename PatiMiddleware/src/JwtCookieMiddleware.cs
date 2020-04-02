using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Pati.Middleware
{
    /// <summary>
    /// Middleware that gets jwt as cookie and sets the user for the application.
    /// </summary>
    public static class JwtCookieMiddleware
    {
        /// <summary>
        /// Checks the jwt cookie and sets the user for the application.
        /// </summary>
        /// <param name="app">App builder reference.</param>
        /// <param name="key">The key to decrypt the token.</param>
        /// <param name="cookieName">Name of the cookie where the jwt is (defaults to jwt).</param>
        public static void UseJwtCookieMiddleware(this IApplicationBuilder app, byte[] key, string cookieName = "jwt")
        {
            app.Use(async (context, next) =>
            {
                string jwtStr = context.Request.Cookies[cookieName];

                if (string.IsNullOrEmpty(jwtStr))
                {
                    await next();
                    return;
                }

                var validationParameters = new TokenValidationParameters
                {
                    // Clock skew compensates for server time drift.
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    RequireSignedTokens = true,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    // Ensure the token audience matches our audience value (default true):
                    ValidateAudience = false,                    
                    ValidateIssuer = false
                };

                try
                {
                    var claimsPrincipal = new JwtSecurityTokenHandler()
                                              .ValidateToken(jwtStr,
                                                             validationParameters,
                                                             out var rawValidatedToken);
                    //rawValidatedToken.
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity();
                    foreach (var claim in claimsPrincipal.Claims)
                    {
                        if (claim.Type == "iat" ||
                            claim.Type == "exp" ||
                            claim.Type == "nbf")
                        {
                            continue;
                        }

                        claimsIdentity.AddClaim(claim);
                    }
                    ClaimsPrincipal newPrincipal = new ClaimsPrincipal(claimsIdentity);
                    context.User = newPrincipal;

                    var jwtToken = rawValidatedToken as JwtSecurityToken;
                    context.Items[Constants.JwtTokenKey] = jwtToken;
                }
                catch (Exception)
                {
                    // TODO: Log..
                }

                await next();
            });
        }
    }
}
