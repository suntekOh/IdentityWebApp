using DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories;

public interface IAuthorizationRepository
{
    Task<bool> AccessibleToRoutePathAsync(Guid userId, string? routePath, CancellationToken canToken);
}

public class AuthorizationRepository : IAuthorizationRepository
{
    private readonly ApplicationDbContext _dbContext;
    public AuthorizationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AccessibleToRoutePathAsync(Guid userId, string? routePath, CancellationToken canToken)
    {
        canToken.ThrowIfCancellationRequested();
        var query =
            from t1 in _dbContext.Users
            join t2 in _dbContext.UserRoles on t1.Id equals t2.UserId
            join t3 in _dbContext.RolesSecPortalModuleAccesses on t2.RoleId equals t3.RoleId
            join t4 in _dbContext.SecPortalModuleAccessPermissions on t3.PortalModuleAccessId equals t4.PortalModuleAccessId
            where t1.Id.Equals(userId) && t4.RoutingPath.Equals(routePath)
            select t1;

        return await query.AnyAsync(canToken);
    }
}
