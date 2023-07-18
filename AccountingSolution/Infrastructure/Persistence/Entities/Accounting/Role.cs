using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// به منظور نگهداری نقش های سیستم استفاده می شود
/// </summary>
public partial class Role
{
    /// <summary>
    /// شناسه جدول Roles
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// عنوان نقش
    /// </summary>
    public string RoleName { get; set; } = null!;

    public virtual ICollection<AccessControlList> AccessControlLists { get; set; } = new List<AccessControlList>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
