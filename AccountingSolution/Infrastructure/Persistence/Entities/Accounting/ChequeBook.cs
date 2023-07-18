using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری و تعریف اطلاعات مربوط به دسته چک های دریافتی از بانک جهت پرداخت استفاده می شود
/// </summary>
public partial class ChequeBook
{
    /// <summary>
    /// شناسه جدول ChequeBook
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// عنوان دسته چک
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// کد دسته چک
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// شناسه جدول Bank
    /// </summary>
    public long? BankId { get; set; }

    /// <summary>
    /// اولین شماره برگ در دسته چک
    /// </summary>
    public string StartNumber { get; set; } = null!;

    /// <summary>
    /// آخرین شماره برگ در دسته چک
    /// </summary>
    public string EndNumber { get; set; } = null!;

    /// <summary>
    /// تاریخ صدور یا دریافت دسته چک از بانک
    /// </summary>
    public DateTime? IssueDate { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاریخ ایجاد رسید پرداخت
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول User
    /// </summary>
    public long CreateUserId { get; set; }

    public virtual Bank? Bank { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual User CreateUser { get; set; } = null!;
}
