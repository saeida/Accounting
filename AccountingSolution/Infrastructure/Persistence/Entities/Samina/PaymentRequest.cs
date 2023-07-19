using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات مربوط به ددرخواست های پرداخت استفاده می شود
/// </summary>
public partial class PaymentRequest
{
    /// <summary>
    /// شناسه جدول PaymentRequest
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
    /// سریال مربوط به درخواست پرداخت
    /// </summary>
    public string PaymentRequestNumber { get; set; } = null!;

    /// <summary>
    /// تاریخ مربوط به درخواست پرداخت
    /// </summary>
    public DateTime PaymentRequestDate { get; set; }

    /// <summary>
    /// نوع درخواست پرداخت
    /// </summary>
    public byte PaymentRequestType { get; set; }

    /// <summary>
    /// شناسه خارجی جدول CashDesk
    /// </summary>
    public long CashDeskId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Person
    /// </summary>
    public long PersonId { get; set; }

    /// <summary>
    /// شناسه فاکتور خرید یا برگشت فروش بدون ایجاد رابطه
    /// </summary>
    public long? FactorId { get; set; }

    /// <summary>
    /// نوع فاکتور
    /// </summary>
    public byte? FactorType { get; set; }

    /// <summary>
    /// مبلغ پرداخت شده
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاریخ ایجاد درخواست پرداخت
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول User
    /// </summary>
    public long CreateUserId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual CashDesk CashDesk { get; set; } = null!;

    public virtual User CreateUser { get; set; } = null!;

    public virtual FinancialPeriod FinancialPeriod { get; set; } = null!;

    public virtual ICollection<PaymentCommand> PaymentCommands { get; set; } = new List<PaymentCommand>();

    public virtual Person Person { get; set; } = null!;
}
