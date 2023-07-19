using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات استان ها استفاده می شود
/// </summary>
public partial class Province
{
    /// <summary>
    /// شناسه جدول Province
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// عنوان استان
    /// </summary>
    public string Title { get; set; } = null!;

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
