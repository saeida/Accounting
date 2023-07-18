using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات گروه بندی و دسته بندی های اشخاص استفاده می شود
/// </summary>
public partial class GroupPerson
{
    /// <summary>
    /// شناسه جدول GroupPerson
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// عنوان گروه شخص
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// کد گروه شخص
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه پدر هر سطح از اشخاص
    /// </summary>
    public long? ParentId { get; set; }

    /// <summary>
    /// شماره لایه و سطح را مشخص میکند
    /// </summary>
    public byte LevelNumber { get; set; }

    /// <summary>
    /// آیا آخرین لایه است یا خیر . یعنی بعد از این لایه ، اشخاص قرار می گیرند 
    /// </summary>
    public bool EndFlag { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
