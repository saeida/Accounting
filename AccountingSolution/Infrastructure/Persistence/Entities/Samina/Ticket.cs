using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری تیکت های پشتیبانی کاربران و کسب و کارها استفاده می شود
/// </summary>
public partial class Ticket
{
    /// <summary>
    /// شناسه جدول Ticket
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long? BranchId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول User
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    /// سریال تیکت
    /// </summary>
    public string Serial { get; set; } = null!;

    /// <summary>
    /// عنوان تیکت
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// شرح تیکت
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// شناسه خارجی جدول Media جهت ذخیره سازی تصویر
    /// </summary>
    public long? MediaId { get; set; }

    /// <summary>
    /// تاریخ ایجاد سطر در تیکت
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// تاریخ مشاهده و خواندن تیکت
    /// </summary>
    public DateTime? ReadDate { get; set; }

    /// <summary>
    /// مربوط به کدام دپارتمان است
    /// </summary>
    public byte ReferTo { get; set; }

    /// <summary>
    /// آیا این سطر مربوط به کاربر است یا ادمین (T : User - F : Admin)
    /// </summary>
    public bool IsAdmin { get; set; }

    /// <summary>
    /// آیا تیکت بسته شده است - فقط در رکورد آخر ثبت می شود و الباقی F باشند .
    /// </summary>
    public bool IsClose { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Medium? Media { get; set; }

    public virtual User? User { get; set; }
}
