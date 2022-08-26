using System;
using System.Collections.Generic;

namespace DataAccess.Entities.Identity;

public partial class SecPortalModuleAccess
{
    public SecPortalModuleAccess()
    {
        RolesSecPortalModuleAccesses = new HashSet<RolesSecPortalModuleAccess>();
        SecPortalModuleAccessPermissions = new HashSet<SecPortalModuleAccessPermission>();
    }

    public int PortalModuleAccessId { get; set; }
    public int PortalId { get; set; }
    public bool HasSelectPermission { get; set; }
    public bool HasInsertPermission { get; set; }
    public bool HasUpdatePermission { get; set; }
    public bool HasDeletePermission { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTimeOffset? RowCreatedDateTimeUtc { get; set; }
    public string? RowLastUpdatedBy { get; set; }
    public DateTimeOffset? RowLastUpdatedDateTimeUtc { get; set; }
    public byte[] RowVersion { get; set; } = null!;

    public virtual SecPortal Portal { get; set; } = null!;
    public virtual ICollection<RolesSecPortalModuleAccess> RolesSecPortalModuleAccesses { get; set; }
    public virtual ICollection<SecPortalModuleAccessPermission> SecPortalModuleAccessPermissions { get; set; }
}
