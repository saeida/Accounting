using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات مربوط به جزییات اسناد حسابداری استفاده می شود
/// </summary>
public partial class VoucherDetail
{
    /// <summary>
    /// شناسه جدول VoucherDetail
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Voucher
    /// </summary>
    public long VoucherId { get; set; }

    /// <summary>
    /// شماره ردیف جزییات هر سند
    /// </summary>
    public long RowNumber { get; set; }

    /// <summary>
    /// شناسه خارجی جدول AccountTitle مربوط به کد حساب
    /// </summary>
    public long Account { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Person مربوط به کد حساب طرف حساب
    /// </summary>
    public long? PersonId { get; set; }

    /// <summary>
    /// مبلغ بدهکار
    /// </summary>
    public decimal? Debtor { get; set; }

    /// <summary>
    /// مبلغ بستانکار
    /// </summary>
    public decimal? Cridetor { get; set; }

    /// <summary>
    /// شناسه رسید متصل شده به ردیف
    /// </summary>
    public long? AttachmentId { get; set; }

    /// <summary>
    /// نوع رسید متصل شده به ردیف
    /// </summary>
    public byte? AttachmentType { get; set; }

    /// <summary>
    /// توضیحات ردیف سند حسابداری
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاریخ ایجاد ردیف سند حسابداری
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول User
    /// </summary>
    public long CreateUserId { get; set; }

    public virtual User CreateUser { get; set; } = null!;

    public virtual Person? Person { get; set; }

    public virtual Voucher Voucher { get; set; } = null!;
}
