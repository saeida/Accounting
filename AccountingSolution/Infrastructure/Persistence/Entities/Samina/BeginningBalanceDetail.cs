using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات مربوط به جزییات موجودی ابتدای دوره کالا استفاده می شود
/// </summary>
public partial class BeginningBalanceDetail
{
    /// <summary>
    /// شناسه جدول BeginningBalanceDetail
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول BeginningBalance
    /// </summary>
    public long BeginningBalanceId { get; set; }

    /// <summary>
    /// شماره ردیف جزییات هر سند
    /// </summary>
    public long RowNumber { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Warehouse
    /// </summary>
    public long? WarehouseId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Product
    /// </summary>
    public long ProductId { get; set; }

    /// <summary>
    /// مقدار اصلی
    /// </summary>
    public decimal MainAmount { get; set; }

    /// <summary>
    /// مقدار فرعی
    /// </summary>
    public decimal? SecondAmount { get; set; }

    /// <summary>
    /// مبلغ واحد
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// قیمت تمام شده کالا
    /// </summary>
    public decimal? FixedPrice { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاریخ ایجاد جزییات فاکتور
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول User
    /// </summary>
    public long CreateUserId { get; set; }

    public virtual BeginningBalance BeginningBalance { get; set; } = null!;

    public virtual User CreateUser { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Warehouse? Warehouse { get; set; }
}
