using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات گروه بندی و دسته بندی های کالا استفاده می شود
/// </summary>
public partial class ProductGroup
{
    /// <summary>
    /// شناسه جدول ProductGroup
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// عنوان گروه بندی کالا
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// کد گروه بندی کالا
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه پدر هر سطح ازکالا
    /// </summary>
    public long? ParentId { get; set; }

    /// <summary>
    /// شماره لایه و سطح را مشخص میکند
    /// </summary>
    public byte LevelNumber { get; set; }

    /// <summary>
    /// آیا آخرین لایه است یا خیر . یعنی بعد از این لایه ، کالا قرار می گیرند 
    /// </summary>
    public bool EndFlag { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
