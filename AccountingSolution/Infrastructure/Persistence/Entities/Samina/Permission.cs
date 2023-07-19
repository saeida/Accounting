using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// تعیین سطح دسترسی ها برای هر فرم
/// </summary>
public partial class Permission
{
    /// <summary>
    /// شناسه جدول Permission
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// نوع سطح دسترسی مشخص می شود
    /// </summary>
    public string PermissionType { get; set; } = null!;

    /// <summary>
    /// فرم یا بخشی که قرار است سطح دسترسی به آن اعمال شود
    /// </summary>
    public long ModuleId { get; set; }

    public virtual ICollection<AccessControlList> AccessControlLists { get; set; } = new List<AccessControlList>();

    public virtual Module Module { get; set; } = null!;
}
