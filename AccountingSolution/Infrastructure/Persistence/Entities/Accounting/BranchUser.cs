using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری ارتباط کاربر و کسب و کار نرم افزار استفاده می شود
/// </summary>
public partial class BranchUser
{
    /// <summary>
    /// شناسه جدول BranchUser
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول User
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// کسب و کار پیش فرض هر کاربر
    /// </summary>
    public bool IsDefault { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
