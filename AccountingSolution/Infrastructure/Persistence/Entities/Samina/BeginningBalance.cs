using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات مربوط به موجودی ابتدای دوره کالا استفاده می شود
/// </summary>
public partial class BeginningBalance
{
    /// <summary>
    /// شناسه جدول BeginningBalance
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول FinancialPeriod
    /// </summary>
    public long FinancialPeriodId { get; set; }

    /// <summary>
    /// شماره فاکتور
    /// </summary>
    public string InvoiceNumber { get; set; } = null!;

    /// <summary>
    /// تاریخ فاکتور
    /// </summary>
    public DateTime InvoiceDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Warehouse
    /// </summary>
    public long? WarehouseId { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاریخ ایجاد فاکتور
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول User
    /// </summary>
    public long CreateUserId { get; set; }

    public virtual ICollection<BeginningBalanceDetail> BeginningBalanceDetails { get; set; } = new List<BeginningBalanceDetail>();

    public virtual Branch Branch { get; set; } = null!;

    public virtual User CreateUser { get; set; } = null!;

    public virtual FinancialPeriod FinancialPeriod { get; set; } = null!;

    public virtual Warehouse? Warehouse { get; set; }
}
