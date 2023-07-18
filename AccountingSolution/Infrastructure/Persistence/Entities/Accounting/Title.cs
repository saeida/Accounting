using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات عناوین اشخاص استفاده می شود
/// </summary>
public partial class Title
{
    /// <summary>
    /// شناسه جدول Title
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// عنوان شخص
    /// </summary>
    public string Title1 { get; set; } = null!;

    /// <summary>
    /// نوع عنوان ( T : حقیقی F : حقوقی)
    /// </summary>
    public bool? TitleType { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
