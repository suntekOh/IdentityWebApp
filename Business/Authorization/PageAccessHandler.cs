using Common.Entities.Identity;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Authorization;

public class PageAccessRequirement : IAuthorizationRequirement
{
}


public class PageAccessHandler : AuthorizationHandler<PageAccessRequirement>
{
    private readonly UserManager<User> _userManager;
    private readonly IAuthorizationRepository _repo;
    public PageAccessHandler(UserManager<User> userManager, IAuthorizationRepository repo)
    {
        _userManager = userManager;
        _repo = repo;
    }
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context, PageAccessRequirement requirement)
    {
        if (context.Resource is AuthorizationFilterContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            var user = await _userManager.GetUserAsync(httpContext.User);

            if(user == default)
            {
                context.Fail();
            }
            else
            {
                var path = httpContext.Request.Path.Value;
                CancellationTokenSource cts = new CancellationTokenSource();

                if (await _repo.AccessibleToRoutePathAsync(user.Id, path, cts.Token))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
        }
        else
        {
            context.Fail();
        }
    }
}