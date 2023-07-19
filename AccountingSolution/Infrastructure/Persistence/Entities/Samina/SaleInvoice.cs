using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات مربوط به فروش کالا استفاده می شود
/// </summary>
public partial class SaleInvoice
{
    /// <summary>
    /// شناسه جدول SaleInvoice
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
    /// شناسه خارجی جدول Person - مشتری
    /// </summary>
    public long Customer { get; set; }

    /// <summary>
    /// عنوان مشتری در فاکتور فروش
    /// </summary>
    public string? CustomerTitle { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Warehouse
    /// </summary>
    public long? WarehouseId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Person - بازاریاب
    /// </summary>
    public long? Visitor { get; set; }

    /// <summary>
    /// درصد محاسبه شده بابت این فاکتور برای ویزیتور
    /// </summary>
    public decimal? VisitorPercent { get; set; }

    /// <summary>
    /// هزینه حمل کالا
    /// </summary>
    public decimal? TransportCost { get; set; }

    /// <summary>
    /// تاریخ انقضای پیش فاکتور
    /// </summary>
    public DateTime? ExpiredDate { get; set; }

    /// <summary>
    /// تاریخ تحویل فاکتور به مشتری
    /// </summary>
    public DateTime? DeliveryDate { get; set; }

    /// <summary>
    /// تاریخ سررسید
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// مبلغ تخفیف که روی کل فاکتور ثبت می شود
    /// </summary>
    public decimal? TotalDiscountAmount { get; set; }

    /// <summary>
    /// درصد تخفیف که روی کل فاکتور ثبت می شود
    /// </summary>
    public decimal? TotalDiscountPercent { get; set; }

    /// <summary>
    /// شماره فاکتور در فروشگاه و سایت اینترنتی
    /// </summary>
    public string? StoreInvoiceNumber { get; set; }

    /// <summary>
    /// شماره فاکتور برگشت فروش
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

    public virtual User CreateUser { get; set; } = null!;

    public virtual Person CustomerNavigation { get; set; } = null!;

    public virtual FinancialPeriod FinancialPeriod { get; set; } = null!;

    public virtual ICollection<SaleInvoiceDetail> SaleInvoiceDetails { get; set; } = new List<SaleInvoiceDetail>();

    public virtual Person? VisitorNavigation { get; set; }

    public virtual Warehouse? Warehouse { get; set; }
}
