using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری پلن های خریداری شده برای هر فروشگاه استفاده می شود
/// </summary>
public partial class BranchPlan
{
    /// <summary>
    /// شناسه جدول BranchPlan
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Plan
    /// </summary>
    public long PlanId { get; set; }

    /// <summary>
    /// قیمت پلن خریداری شده
    /// </summary>
    public decimal BuyPrice { get; set; }

    /// <summary>
    /// تخفیف پلن خریداری شده
    /// </summary>
    public decimal? DiscountedPrice { get; set; }

    /// <summary>
    /// تاریخ شروع پلن
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان پلن
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// تاریخ ایجاد پلن
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// تاریخ پرداخت در درگاه پرداخت
    /// </summary>
    public DateTime? PayDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول بانک درگاه پرداخت
    /// </summary>
    public long? PayBankId { get; set; }

    /// <summary>
    /// کد پیگیری برگشتی از درگاه پرداخت
    /// </summary>
    public string? PayCode { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual PublicEnum? PayBank { get; set; }

    public virtual Plan Plan { get; set; } = null!;
}
