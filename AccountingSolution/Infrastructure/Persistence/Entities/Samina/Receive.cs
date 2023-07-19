using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات مربوط دریافت کلیه وجوه و اسناد استفاده می شود . عموما بوسیله فروش کالا و یا برگشت خرید پر می شود
/// </summary>
public partial class Receive
{
    /// <summary>
    /// شناسه جدول Receive
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
    /// شماره رسید دریافت
    /// </summary>
    public string ReceiveNumber { get; set; } = null!;

    /// <summary>
    /// تاریخ دریافت
    /// </summary>
    public DateTime ReceiveDate { get; set; }

    /// <summary>
    /// نوع دریافت وجه را مشخص می کند
    /// </summary>
    public byte ReceiveType { get; set; }

    /// <summary>
    /// شناسه خارجی جدول CashDesk
    /// </summary>
    public long CashDeskId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Person
    /// </summary>
    public long PersonId { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاریخ ایجاد رسید دریافت
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول User
    /// </summary>
    public long CreateUserId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual CashDesk CashDesk { get; set; } = null!;

    public virtual ICollection<ChequeTurnover> ChequeTurnovers { get; set; } = new List<ChequeTurnover>();

    public virtual User CreateUser { get; set; } = null!;

    public virtual FinancialPeriod FinancialPeriod { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<ReceiveDetail> ReceiveDetails { get; set; } = new List<ReceiveDetail>();
}
