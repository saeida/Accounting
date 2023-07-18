using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری آخرین موجودی کالا استفاده می شود
/// </summary>
public partial class WarehouseStock
{
    /// <summary>
    /// شناسه جدول WarehouseStock
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Warehouse
    /// </summary>
    public long WarehouseId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول FinancialPeriod
    /// </summary>
    public long FinancialPeriodId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Product
    /// </summary>
    public long ProductId { get; set; }

    /// <summary>
    /// مقدار موجودی کالا در انبار و سال مالی مربوطه برای هر کسب و کار
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// آخرین مبلغ خرید کالا
    /// </summary>
    public decimal? BuyPrice { get; set; }

    /// <summary>
    /// مبلغ فروش کالا (محاسبه بر اساس قیمت خرید و درصد ذکر شده معرفی کالا)
    /// </summary>
    public decimal? SalePrice { get; set; }

    /// <summary>
    /// مبلغ فروش عمده (محاسبه بر اساس قیمت خرید و درصد ذکر شده معرفی کالا)
    /// </summary>
    public decimal? WholePrice { get; set; }

    /// <summary>
    /// مبلغ فروش به نماینده (محاسبه بر اساس قیمت خرید و درصد ذکر شده معرفی کالا)
    /// </summary>
    public decimal? AgentPrice { get; set; }

    /// <summary>
    /// مربوط به تکنیک Optimistic Concurrency
    /// </summary>
    public byte[] RecordVersion { get; set; } = null!;

    public virtual Branch Branch { get; set; } = null!;

    public virtual FinancialPeriod FinancialPeriod { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
