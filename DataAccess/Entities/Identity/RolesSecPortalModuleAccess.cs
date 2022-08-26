using System;
using System.Collections.Generic;

namespace DataAccess.Entities.Identity;

public partial class RolesSecPortalModuleAccess
{
    public Guid RoleId { get; set; }
    public int PortalModuleAccessId { get; set; }
    public bool HasSelectPermission { get; set; }
    public bool HasInsertPermission { get; set; }
    public bool HasUpdatePermission { get; set; }
    public bool HasDeletePermission { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTimeOffset? RowCreatedDateTimeUtc { get; set; }
    public string? RowLastUpdatedBy { get; set; }
    public DateTimeOffset? RowLastUpdatedDateTimeUtc { get; set; }
    public byte[] RowVersion { get; set; } = null!;

    public virtual SecPortalModuleAccess PortalModuleAccess { get; set; } = null!;
    public virtual Role Role { get; set; } = null!;
}

