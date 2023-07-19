using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات واحدهای اندازه گیری استفاده می شود
/// </summary>
public partial class Unit
{
    /// <summary>
    /// شناسه جدول Unit
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// عنوان واحد اندازه گیری
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// کد واحد اندازه گیری
    /// </summary>
    public string Code { get; set; } = null!;
}
