using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری سطح دسترسی هر نقش استفاده می شود
/// </summary>
public partial class AccessControlList
{
    /// <summary>
    /// شناسه جدول AccessControlList
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Roles
    /// </summary>
    public long RoleId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Permission
    /// </summary>
    public long PermissionId { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
