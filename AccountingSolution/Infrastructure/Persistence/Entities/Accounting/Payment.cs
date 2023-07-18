using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات مربوط پرداخت کلیه وجوه و اسناد استفاده می شود . عموما بوسیله خرید کالا و یا برگشت فروش پر می شود 
/// </summary>
public partial class Payment
{
    /// <summary>
    /// شناسه جدول Payment
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
    /// شماره رسید پرداخت
    /// </summary>
    public string PaymentNumber { get; set; } = null!;

    /// <summary>
    /// تاریخ پرداخت
    /// </summary>
    public DateTime PaymentDate { get; set; }

    /// <summary>
    /// نوع پرداخت وجه را مشخص می کند
    /// </summary>
    public byte PaymentType { get; set; }

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
    /// وضعیت وصول چک
    /// </summary>
    public byte ReceiptStatus { get; set; }

    /// <summary>
    /// تاریخ وصول چک
    /// </summary>
    public DateTime? ReceiptDate { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاریخ ایجاد رسید پرداخت
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول User
    /// </summary>
    public long CreateUserId { get; set; }

    public virtual Bank? Bank { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual CashDesk CashDesk { get; set; } = null!;

    public virtual PublicEnum? ChequeBank { get; set; }

    public virtual User CreateUser { get; set; } = null!;

    public virtual FinancialPeriod FinancialPeriod { get; set; } = null!;

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();

    public virtual Person Person { get; set; } = null!;
}
