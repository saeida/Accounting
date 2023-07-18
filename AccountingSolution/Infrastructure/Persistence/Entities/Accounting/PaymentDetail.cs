using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات مربوط به جزییات پرداخت استفاده می شود
/// </summary>
public partial class PaymentDetail
{
    /// <summary>
    /// شناسه جدول ChequeTurnover
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Payment
    /// </summary>
    public long PaymentId { get; set; }

    /// <summary>
    /// سریال مربوط به جزییات پرداخت
    /// </summary>
    public string PaymentDetailNumber { get; set; } = null!;

    /// <summary>
    /// تاریخ مربوط به جزییات پرداخت
    /// </summary>
    public DateTime PaymentDetailDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Person
    /// </summary>
    public long PersonId { get; set; }

    /// <summary>
    /// مبلغ مربوط به جزییات پرداخت
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاریخ ایجاد رسید جزییات پرداخت
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول User
    /// </summary>
    public long CreateUserId { get; set; }

    public virtual User CreateUser { get; set; } = null!;

    public virtual Payment Payment { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
