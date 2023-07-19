using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات مربوط گردش اسناد و چک ها استفاده می شود
/// </summary>
public partial class ChequeTurnover
{
    /// <summary>
    /// شناسه جدول ChequeTurnover
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Receive
    /// </summary>
    public long ReceiveId { get; set; }

    /// <summary>
    /// وضعیت گردش
    /// </summary>
    public byte Status { get; set; }

    /// <summary>
    /// تاریخ ثبت گردش
    /// </summary>
    public DateTime StatusDate { get; set; }

    /// <summary>
    /// شناسه جدول Bank
    /// </summary>
    public long? BankId { get; set; }

    /// <summary>
    /// شماره فیش یا ارجاع بابت واگذاری
    /// </summary>
    public string? Serial { get; set; }

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

    public virtual User CreateUser { get; set; } = null!;

    public virtual Receive Receive { get; set; } = null!;
}
