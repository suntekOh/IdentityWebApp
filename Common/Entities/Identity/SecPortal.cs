using System;
using System.Collections.Generic;

namespace Common.Entities.Identity;

public partial class SecPortal
{
    public SecPortal()
    {
        SecPortalModules = new HashSet<SecPortalModule>();
    }

    public int PortalId { get; set; }
    public string PortalName { get; set; } = null!;
    public string? RowCreatedBy { get; set; }
    public DateTimeOffset? RowCreatedDateTimeUtc { get; set; }
    public string? RowLastUpdatedBy { get; set; }
    public DateTimeOffset? RowLastUpdatedDateTimeUtc { get; set; }
    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<SecPortalModule> SecPortalModules { get; set; }
}

