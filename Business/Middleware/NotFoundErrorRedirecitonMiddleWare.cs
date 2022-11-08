using Common.Entities.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace IdentityBusiness.Middleware;

public class NotFoundErrorRedirecitonMiddleWare
{
    private readonly RequestDelegate _next;

    public NotFoundErrorRedirecitonMiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, SignInManager<User> signInManager, LinkGenerator linkGenerator)
    {
        await _next(context);

        var returnUrl = string.Empty;

        if (context.Response.StatusCode == StatusCodes.Status404NotFound)
        {
            if (signInManager.IsSignedIn(context.User))
            {
                returnUrl = linkGenerator.GetUriByAction(context, string.Empty, string.Empty);
            }
            else
            {
                returnUrl = linkGenerator.GetUriByPage(context, "/Account/Login", null, new { Area = "Identity"});
            }
            
            context.Response.Redirect(returnUrl);
        }
    }
}

public static class NotFoundErrorRedirecitonMiddleWareExtensions
{
    public static IApplicationBuilder UseNotFoundErrorRedireciton(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<NotFoundErrorRedirecitonMiddleWare>();
    }
}
