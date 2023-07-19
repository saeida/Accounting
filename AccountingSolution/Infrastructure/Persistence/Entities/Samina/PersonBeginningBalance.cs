using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات مربوط به مانده ریالی اشخاص استفاده می شود
/// </summary>
public partial class PersonBeginningBalance
{
    /// <summary>
    /// شناسه جدول PersonBeginningBalance
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long? BranchId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول FinancialPeriod
    /// </summary>
    public long? FinancialPeriodId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Person
    /// </summary>
    public long? PersonId { get; set; }

    /// <summary>
    /// مبلغ مانده ابتدای دوره
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// وضعیت بدهکار یا بستانکار بودن مانده
    /// </summary>
    public bool? Status { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual FinancialPeriod? FinancialPeriod { get; set; }

    public virtual Person? Person { get; set; }
}
