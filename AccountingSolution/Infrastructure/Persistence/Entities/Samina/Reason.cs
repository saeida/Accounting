using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری دلایل غیرفعال کردن استفاده می شود
/// </summary>
public partial class Reason
{
    /// <summary>
    /// شناسه جدول Reason
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// عنوان دلیل
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// کد دلیل
    /// </summary>
    public string Code { get; set; } = null!;

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<DeactiveReason> DeactiveReasons { get; set; } = new List<DeactiveReason>();
}
