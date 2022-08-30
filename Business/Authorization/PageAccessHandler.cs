using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Authorization;

public class PageAccessRequirement : IAuthorizationRequirement
{
}


public class PageAccessHandler : AuthorizationHandler<PageAccessRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context, PageAccessRequirement requirement)
    {
        if (context.Resource is AuthorizationFilterContext filterContext)
        {
            var path = filterContext.HttpContext.Request.Path;
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;
    }
}