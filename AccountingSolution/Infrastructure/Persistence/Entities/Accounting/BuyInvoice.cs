using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات مربوط به خرید کالا استفاده می شود
/// </summary>
public partial class BuyInvoice
{
    /// <summary>
    /// شناسه جدول BuyInvoice
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
    /// نوع فاکتور
    /// </summary>
    public byte InvoiceType { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Person - فروشنده
    /// </summary>
    public long Saler { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Warehouse
    /// </summary>
    public long? WarehouseId { get; set; }

    /// <summary>
    /// شماره فاکتور مربوط به فروشنده
    /// </summary>
    public string? SalerInvoiceNumber { get; set; }

    /// <summary>
    /// تاریخ فاکتور مربوط به فروشنده
    /// </summary>
    public DateTime? SalerInvoiceDate { get; set; }

    /// <summary>
    /// هزینه حمل کالا
    /// </summary>
    public decimal? TransportCost { get; set; }

    /// <summary>
    /// مبلغ تخفیف که روی کل فاکتور ثبت می شود
    /// </summary>
    public decimal? TotalDiscountAmount { get; set; }

    /// <summary>
    /// درصد تخفیف که روی کل فاکتور ثبت می شود
    /// </summary>
    public decimal? TotalDiscountPercent { get; set; }

    /// <summary>
    /// شماره فاکتور برگشت خرید
    /// </summary>
    public string? RelatedInvoiceNumber { get; set; }

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

    public virtual ICollection<BuyInvoiceDetail> BuyInvoiceDetails { get; set; } = new List<BuyInvoiceDetail>();

    public virtual User CreateUser { get; set; } = null!;

    public virtual FinancialPeriod FinancialPeriod { get; set; } = null!;

    public virtual Person SalerNavigation { get; set; } = null!;

    public virtual Warehouse? Warehouse { get; set; }
}
