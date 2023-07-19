using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات پایه ای در سیستم استفاده می شود
/// </summary>
public partial class PublicEnum
{
    /// <summary>
    /// شناسه جدول PublicEnum
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// عنوان اطلاعات عمومی
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// کد عنوان عمومی
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// نوع و دسته بندی اطلاعات پایه
    /// </summary>
    public byte Type { get; set; }

    public virtual ICollection<BranchPlan> BranchPlans { get; set; } = new List<BranchPlan>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<ReceiveDetail> ReceiveDetails { get; set; } = new List<ReceiveDetail>();
}
