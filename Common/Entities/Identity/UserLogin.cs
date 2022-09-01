using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.Identity;

public class UserLogin : IdentityUserLogin<Guid>
{
    public string? RowCreatedBy { get; set; }
    public DateTimeOffset? RowCreatedDateTimeUtc { get; set; }
    public string? RowLastUpdatedBy { get; set; }
    public DateTimeOffset? RowLastUpdatedDateTimeUtc { get; set; }
    public byte[] RowVersion { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
