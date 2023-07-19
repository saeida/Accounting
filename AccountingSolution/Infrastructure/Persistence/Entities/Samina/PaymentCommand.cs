using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری و تعریف اطلاعات مربوط به دستورات پرداخت  وصدور چک / تامین اعتبار استفاده می شود
/// </summary>
public partial class PaymentCommand
{
    /// <summary>
    /// شناسه جدول PaymentCommand
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول PaymentRequest
    /// </summary>
    public long PaymentRequestId { get; set; }

    /// <summary>
    /// اولویت صدور چک
    /// </summary>
    public byte Priority { get; set; }

    /// <summary>
    /// شناسه جدول Bank
    /// </summary>
    public long? BankId { get; set; }

    /// <summary>
    /// سریال چک صادر شده
    /// </summary>
    public string? ChequeSerial { get; set; }

    /// <summary>
    /// تاریخ صدور چک
    /// </summary>
    public DateTime? ChequeDate { get; set; }

    /// <summary>
    /// بابت چک صادر شده
    /// </summary>
    public string? ChequeDescription { get; set; }

    /// <summary>
    /// تاریخ ایجاد دستور پرداخت
    /// </summary>
    public DateTime CommandCreationDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول User بابت دستور پرداخت
    /// </summary>
    public long CommandCreationUserId { get; set; }

    /// <summary>
    /// تاریخ ایجاد صدور چک
    /// </summary>
    public DateTime? SodorCreationDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول User بابت صدور چک
    /// </summary>
    public long? SodorCreationUserId { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    public virtual Bank? Bank { get; set; }

    public virtual User CommandCreationUser { get; set; } = null!;

    public virtual PaymentRequest PaymentRequest { get; set; } = null!;

    public virtual User? SodorCreationUser { get; set; }
}
