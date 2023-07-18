using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات مربوط به جزییات فروش کالا استفاده می شود
/// </summary>
public partial class SaleInvoiceDetail
{
    /// <summary>
    /// شناسه جدول SaleInvoiceDetail
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول SaleInvoice
    /// </summary>
    public long SaleInvoiceId { get; set; }

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
    /// تخفیف مربوط به هر کالا
    /// </summary>
    public decimal? Discount { get; set; }

    /// <summary>
    /// درصد تخفیف مربوط به هر کالا
    /// </summary>
    public decimal? DiscountPercent { get; set; }

    /// <summary>
    /// مبلغ مالیات بر ارزش افزوده
    /// </summary>
    public decimal? Vat1 { get; set; }

    /// <summary>
    /// مبلغ عوارض ارزش افزوده
    /// </summary>
    public decimal? Vat2 { get; set; }

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

    public virtual User CreateUser { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual SaleInvoice SaleInvoice { get; set; } = null!;

    public virtual Warehouse? Warehouse { get; set; }
}
