using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

public partial class RefreshToken
{
    public long Id { get; set; }

    /// <summary>
    /// شناسه کاربر درخواست کننده توکن و رفرش توکن
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    /// توکن
    /// </summary>
    public string? Token { get; set; }

    /// <summary>
    /// شناسه توکن اصلی
    /// </summary>
    public string? JwtId { get; set; }

    /// <summary>
    /// آیا از رفرش توکن قبلا جهت دریافت نسخه جدید استفاده شده؟
    /// </summary>
    public bool? IsUsed { get; set; }

    /// <summary>
    /// آیا رفرش توکن کنسل شده است؟
    /// </summary>
    public bool? IsRevoked { get; set; }

    /// <summary>
    /// تاریخ ثبت
    /// </summary>
    public DateTime? AddedDate { get; set; }

    /// <summary>
    /// تاریخ انقضا
    /// </summary>
    public DateTime? ExpiryDate { get; set; }

    public virtual User? User { get; set; }
}
