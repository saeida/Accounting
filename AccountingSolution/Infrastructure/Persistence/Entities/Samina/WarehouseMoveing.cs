using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات مربوط به جابه جایی کالا بین انبارها استفاده می شود
/// </summary>
public partial class WarehouseMoveing
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
    /// شناسه خارجی جدول Warehouse - انبار مبدا
    /// </summary>
    public long? WarehouseInId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Warehouse - انبار مقصد
    /// </summary>
    public long? WarehouseOutId { get; set; }

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

    public virtual Branch Branch { get; set; } = null!;

    public virtual User CreateUser { get; set; } = null!;

    public virtual FinancialPeriod FinancialPeriod { get; set; } = null!;

    public virtual Warehouse? WarehouseIn { get; set; }

    public virtual ICollection<WarehouseMoveingDetail> WarehouseMoveingDetails { get; set; } = new List<WarehouseMoveingDetail>();

    public virtual Warehouse? WarehouseOut { get; set; }
}
