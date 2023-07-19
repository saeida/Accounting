using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// به منظور نگهداری عناوین فرم ها و بخش های سیستم که به آنها سطح دسترسی اعمال می شود استفاده میکنیم
/// </summary>
public partial class Module
{
    /// <summary>
    /// شناسه جدول Module
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// عنوان فرم یا بخشی که سطح دسترسی به آن اعمال می شود
    /// </summary>
    public string ModuleName { get; set; } = null!;

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
