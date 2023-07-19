using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری کلیه تصاویر به شکل باینری در دیتابیس استفاده می شود
/// </summary>
public partial class Medium
{
    /// <summary>
    /// شناسه جدول Media
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// راهنمای سایزهای مختلف - جیسون
    /// </summary>
    public string? GuideSize { get; set; }

    /// <summary>
    /// محتوای عکس بارگذاری شده شماره 1
    /// </summary>
    public byte[]? Content1 { get; set; }

    /// <summary>
    /// محتوای عکس بارگذاری شده شماره 2
    /// </summary>
    public byte[]? Content2 { get; set; }

    /// <summary>
    /// محتوای عکس بارگذاری شده شماره 3
    /// </summary>
    public byte[]? Content3 { get; set; }

    /// <summary>
    /// محتوای عکس بارگذاری شده شماره 4
    /// </summary>
    public byte[]? Content4 { get; set; }

    /// <summary>
    /// محتوای عکس بارگذاری شده شماره 5
    /// </summary>
    public byte[]? Content5 { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
