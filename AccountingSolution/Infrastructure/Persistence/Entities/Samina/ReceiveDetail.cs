using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات مربوط به جزییات دریافت کلیه وجوه و اسناد استفاده می شود . عموما بوسیله فروش کالا و یا برگشت خرید پر می شود
/// </summary>
public partial class ReceiveDetail
{
    /// <summary>
    /// شناسه جدول Receive
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Receive
    /// </summary>
    public long ReceiveId { get; set; }

    /// <summary>
    /// شناسه فاکتور فروش یا برگشت خرید بدون ایجاد رابطه
    /// </summary>
    public long? FactorId { get; set; }

    /// <summary>
    /// نوع فاکتور
    /// </summary>
    public byte? FactorType { get; set; }

    /// <summary>
    /// مبلغ دریافت شده
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// سریال سند / چک
    /// </summary>
    public string? ChequeSerial { get; set; }

    /// <summary>
    /// تاریخ سند / چک
    /// </summary>
    public DateTime? ChequeDate { get; set; }

    /// <summary>
    /// شماره حساب سند / چک
    /// </summary>
    public string? ChequeAccountNumber { get; set; }

    /// <summary>
    /// توضیحات سند  / بابت چک
    /// </summary>
    public string? ChequeDescription { get; set; }

    /// <summary>
    /// شناسه جدول PublicEnum با گروه 01
    /// </summary>
    public long? ChequeBankId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Bank
    /// </summary>
    public long? BankId { get; set; }

    /// <summary>
    /// شعبه بانک
    /// </summary>
    public string? BankBranch { get; set; }

    /// <summary>
    /// چک ضمانت است یا جاری؟
    /// </summary>
    public bool? IsGarantyCheque { get; set; }

    /// <summary>
    /// آیا صندوق بسته شده یا خیر؟
    /// </summary>
    public bool IsInClosedCash { get; set; }

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

    public virtual Bank? Bank { get; set; }

    public virtual PublicEnum? ChequeBank { get; set; }

    public virtual User CreateUser { get; set; } = null!;

    public virtual Receive Receive { get; set; } = null!;
}
