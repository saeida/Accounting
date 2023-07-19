using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات مربوط به اسناد حسابداری استفاده می شود
/// </summary>
public partial class Voucher
{
    /// <summary>
    /// شناسه جدول Voucher
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
    /// شماره سند موقت
    /// </summary>
    public string VoucherNumberTemp { get; set; } = null!;

    /// <summary>
    /// تاریخ سند موقت
    /// </summary>
    public DateTime VoucherDateTemp { get; set; }

    /// <summary>
    /// شماره سند تایید شده
    /// </summary>
    public string? VoucherNumber { get; set; }

    /// <summary>
    /// تاریخ تایید سند 
    /// </summary>
    public DateTime? VoucherDate { get; set; }

    /// <summary>
    /// نوع سند
    /// </summary>
    public byte VoucherType { get; set; }

    /// <summary>
    /// نوع کارتابل
    /// </summary>
    public byte Cartable { get; set; }

    /// <summary>
    /// آیا سند اتوماتیک است یا خیر
    /// </summary>
    public bool IsAutomatic { get; set; }

    /// <summary>
    /// توضیحات سند حسابداری
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاریخ ایجاد سند حسابداری
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول User
    /// </summary>
    public long CreateUserId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual User CreateUser { get; set; } = null!;

    public virtual FinancialPeriod FinancialPeriod { get; set; } = null!;

    public virtual ICollection<LockedDocument> LockedDocuments { get; set; } = new List<LockedDocument>();

    public virtual ICollection<VoucherDetail> VoucherDetails { get; set; } = new List<VoucherDetail>();
}
