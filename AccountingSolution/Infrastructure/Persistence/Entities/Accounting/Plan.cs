using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری پلن ها و طرح های فروش مربوط به نرم افزار نگهداری می شود
/// </summary>
public partial class Plan
{
    /// <summary>
    /// شناسه جدول Plan
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// عنوان طرح فروش
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// مبلغ طرح فروش
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// مبلغ پس از تخفیف در طرح فروش
    /// </summary>
    public decimal? DiscountedPrice { get; set; }

    /// <summary>
    /// مشخصات و قابلیت های هر طرح با فرمت جیسون
    /// </summary>
    public string Property { get; set; } = null!;

    /// <summary>
    /// وضعیت فعال بودن طرح
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// دوره زمانی هر طرح که چقدر طول می کشد  بر اساس تعداد ماه
    /// </summary>
    public byte Period { get; set; }

    /// <summary>
    /// تاریخ ایجاد کاربر
    /// </summary>
    public DateTime CreateDate { get; set; }

    public virtual ICollection<BranchPlan> BranchPlans { get; set; } = new List<BranchPlan>();
}
