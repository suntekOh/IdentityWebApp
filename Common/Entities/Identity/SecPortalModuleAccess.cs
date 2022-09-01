using Common.Entities.Identity;
using System;
using System.Collections.Generic;

namespace Common.Entities.Identity;

public partial class SecPortalModuleAccess
{
    public SecPortalModuleAccess()
    {
        RolesSecPortalModuleAccesses = new HashSet<RolesSecPortalModuleAccess>();
        SecPortalModuleAccessPermissions = new HashSet<SecPortalModuleAccessPermission>();
    }

    public int PortalModuleAccessId { get; set; }
    public int PortalModuleId { get; set; }
    public string? PortalModuleAccessName { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTimeOffset? RowCreatedDateTimeUtc { get; set; }
    public string? RowLastUpdatedBy { get; set; }
    public DateTimeOffset? RowLastUpdatedDateTimeUtc { get; set; }
    public byte[] RowVersion { get; set; } = null!;

    public virtual SecPortalModule PortalModule { get; set; } = null!;
    public virtual ICollection<RolesSecPortalModuleAccess> RolesSecPortalModuleAccesses { get; set; }
    public virtual ICollection<SecPortalModuleAccessPermission> SecPortalModuleAccessPermissions { get; set; }
}

