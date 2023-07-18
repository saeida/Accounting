using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات سرفصل های حسابداری استفاده می شود
/// </summary>
public partial class AccountTitle
{
    /// <summary>
    /// شناسه جدول AccountTitle
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// عنوان سرفصل حسابداری
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// کد سرفصل حسابداری
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// کد کامل شامل کدهای پدر سرفصل حسابداری
    /// </summary>
    public string FullCode { get; set; } = null!;

    /// <summary>
    /// شناسه پدر سرفصل حسابداری
    /// </summary>
    public long? ParentId { get; set; }

    /// <summary>
    /// ماهیت حساب
    /// </summary>
    public byte AccountNature { get; set; }

    /// <summary>
    /// نوع حساب
    /// </summary>
    public byte AccountType { get; set; }

    /// <summary>
    /// حساب در چه سطحی است؟
    /// </summary>
    public byte AccountLevel { get; set; }

    /// <summary>
    /// شناسه خارجی جدول PublicEnum با کد 06
    /// </summary>
    public long AccountGroup { get; set; }

    public virtual Branch Branch { get; set; } = null!;
}
