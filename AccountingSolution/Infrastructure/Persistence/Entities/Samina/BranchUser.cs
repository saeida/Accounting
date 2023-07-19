using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

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

    /// <summary>
    /// شناسه جدول نقش
    /// </summary>
    public long RoleId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual Role IdNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
