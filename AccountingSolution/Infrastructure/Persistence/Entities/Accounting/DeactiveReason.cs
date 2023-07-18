using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات غیر فعال کردن اضخاص و ممنوع المعامله کردن افراد استفاده می شود
/// </summary>
public partial class DeactiveReason
{
    /// <summary>
    /// شناسه جدول DeactiveReason
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Person
    /// </summary>
    public long PersonId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Reason
    /// </summary>
    public long ReasonId { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاریخ غیرفعال کردن شخص
    /// </summary>
    public DateTime DeactiveDate { get; set; }

    /// <summary>
    /// تاریخ فعال کردن شخص
    /// </summary>
    public DateTime? ActiveDate { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Reason Reason { get; set; } = null!;
}
