using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات و شرح  های پیش فرض برای ردیف و یا سند در سندهای حسابداری استفاده می شود
/// </summary>
public partial class Template
{
    /// <summary>
    /// شناسه جدول Template
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// عنوان شرح پیش فرض
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// کد شرح پیش فرض
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    public virtual Branch Branch { get; set; } = null!;
}
