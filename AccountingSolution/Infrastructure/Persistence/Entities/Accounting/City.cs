using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات شهر های هر استان ها استفاده می شود
/// </summary>
public partial class City
{
    /// <summary>
    /// شناسه جدول City
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// عنوان شهر
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// شناسه خارجی جدول Province
    /// </summary>
    public long ProvinceId { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual Province Province { get; set; } = null!;
}
