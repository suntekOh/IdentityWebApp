using System;
using System.Collections.Generic;

namespace DataAccess.Entities.Identity;

public partial class SecPortalModuleAccessPermission
{
    public int PortalModuleAccessPermissionId { get; set; }
    public int PortalModuleAccessId { get; set; }
    public string RoutingPath { get; set; } = null!;
    public string Httpverb { get; set; } = null!;
    public string? RowCreatedBy { get; set; }
    public DateTimeOffset? RowCreatedDateTimeUtc { get; set; }
    public string? RowLastUpdatedBy { get; set; }
    public DateTimeOffset? RowLastUpdatedDateTimeUtc { get; set; }
    public byte[] RowVersion { get; set; } = null!;

    public virtual SecPortalModuleAccess SecPortalModuleAccess { get; set; } = null!;
}
