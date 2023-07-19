using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات مربوط به سال مالی هر کسب و کار استفاده می شود
/// </summary>
public partial class FinancialPeriod
{
    /// <summary>
    /// شناسه جدول FinancialPeriod
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// عنوان سال مالی
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// تاریخ شروع سال مالی
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان سال مالی
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// آیا سال مالی پیش فرض است
    /// </summary>
    public bool IsDefault { get; set; }

    public virtual ICollection<BeginningBalance> BeginningBalances { get; set; } = new List<BeginningBalance>();

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<BuyInvoice> BuyInvoices { get; set; } = new List<BuyInvoice>();

    public virtual ICollection<LockedDocument> LockedDocuments { get; set; } = new List<LockedDocument>();

    public virtual ICollection<PaymentRequest> PaymentRequests { get; set; } = new List<PaymentRequest>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<PersonBeginningBalance> PersonBeginningBalances { get; set; } = new List<PersonBeginningBalance>();

    public virtual ICollection<Receive> Receives { get; set; } = new List<Receive>();

    public virtual ICollection<SaleInvoice> SaleInvoices { get; set; } = new List<SaleInvoice>();

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();

    public virtual ICollection<WarehouseMoveing> WarehouseMoveings { get; set; } = new List<WarehouseMoveing>();

    public virtual ICollection<WarehouseStock> WarehouseStocks { get; set; } = new List<WarehouseStock>();
}
