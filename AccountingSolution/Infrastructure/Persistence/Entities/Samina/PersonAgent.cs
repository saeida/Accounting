using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات و ارتباط بین نماینده و مشتری استفاده می شود
/// </summary>
public partial class PersonAgent
{
    /// <summary>
    /// شناسه جدول PersonAgent
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Person
    /// </summary>
    public long PersonId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Person
    /// </summary>
    public long AgentId { get; set; }

    public virtual Person Agent { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
