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
    Task<bool> PermittedToAccess(Guid userId, string routePath, CancellationToken canToken);
}

public class AuthorizationRepository : IAuthorizationRepository
{
    private readonly ApplicationDbContext _dbContext;
    public AuthorizationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<bool> PermittedToAccess(Guid userId, string routePath, CancellationToken canToken)
    {
        //from t1 in _dbContext.SecPortalModuleAccessPermissions
        //join t2 in _dbContext.AspNetRolesSecPortalModuleAccesses on t1.PortalModuleAccessId equals t2.PortalModuleAccessId
        //where t1.RoutingPath.Equals(routePath)

        throw new NotImplementedException();
    }
}
