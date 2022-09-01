using System;
using System.Collections.Generic;

namespace Common.Entities.Identity;

public partial class SecPortalModule
{
    public SecPortalModule()
    {
        SecPortalModuleAccesses = new HashSet<SecPortalModuleAccess>();
    }

    public int PortalModuleId { get; set; }
    public int PortalId { get; set; }
    public string? PortalModuleName { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTimeOffset? RowCreatedDateTimeUtc { get; set; }
    public string? RowLastUpdatedBy { get; set; }
    public DateTimeOffset? RowLastUpdatedDateTimeUtc { get; set; }
    public byte[] RowVersion { get; set; } = null!;

    public virtual SecPortal Portal { get; set; } = null!;
    public virtual ICollection<SecPortalModuleAccess> SecPortalModuleAccesses { get; set; }
}
