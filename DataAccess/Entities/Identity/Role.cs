using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Identity;


namespace DataAccess.Entities.Identity;

public class Role : IdentityRole<Guid>
{
    public Role()
    {
        RoleClaims = new HashSet<RoleClaim>();
        RolesSecPortalModuleAccesses = new HashSet<RolesSecPortalModuleAccess>();
        UserRoles = new HashSet<UserRole>();
    }

    public string? RowCreatedBy { get; set; }
    public DateTimeOffset? RowCreatedDateTimeUtc { get; set; }
    public string? RowLastUpdatedBy { get; set; }
    public DateTimeOffset? RowLastUpdatedDateTimeUtc { get; set; }
    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    public virtual ICollection<RolesSecPortalModuleAccess> RolesSecPortalModuleAccesses { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
}