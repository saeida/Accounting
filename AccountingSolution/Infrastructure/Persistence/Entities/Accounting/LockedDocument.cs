using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات مربوط قفل کردن اسناد انبار و فروش و خزانه داری بر اساس سند حسابداری ثبت و لینک شده به آن ها استفاده می شود
/// </summary>
public partial class LockedDocument
{
    /// <summary>
    /// شناسه جدول LockedDocument
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول FinancialPeriod
    /// </summary>
    public long FinancialPeriodId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Voucher
    /// </summary>
    public long VoucherId { get; set; }

    /// <summary>
    /// شناسه رسید متصل شده به ردیف سند
    /// </summary>
    public long DocumenttId { get; set; }

    /// <summary>
    /// نوع رسید متصل شده به ردیف
    /// </summary>
    public byte DocumentType { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual FinancialPeriod FinancialPeriod { get; set; } = null!;

    public virtual Voucher Voucher { get; set; } = null!;
}
