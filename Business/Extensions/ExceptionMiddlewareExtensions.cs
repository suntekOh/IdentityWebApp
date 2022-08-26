using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;

using System.Net;

namespace Business.Extensions;

public static class ExceptionMiddlewareExtensions
{
    /// <summary>
    /// configure Exception Handler response
    /// </summary>
    /// <param name="app"></param>
    /// <param name="logger"></param>
    public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    await Task.CompletedTask;
                    logger.LogError($"{nameof(ConfigureExceptionHandler)}(): {context.Request.Path.ToString()} => {contextFeature.Error.ToString()}");
                    context.Response.Redirect("/Home/Error");
                }
            });
        });
    }
}