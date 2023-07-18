using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات مربوط به مدیر کسب و کار و یا فروشگاه با ساختار درختی و سلسله مراتبی در نظر گرفته می شود
/// </summary>
public partial class Branch
{
    /// <summary>
    /// شناسه جدول Branch
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// نام کسب و کار یا فروشگاه
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// شناسه خارجی استان محل فروشگاه
    /// </summary>
    public long? ProvinceId { get; set; }

    /// <summary>
    /// شناسه خارجی شهر محل فروشگاه
    /// </summary>
    public long? CityId { get; set; }

    /// <summary>
    /// شناسه پدر و بالا سری فروشگاه  - اگر خالی بود ، یعنی پدر هست و اگر پر بود یعنی فرزند
    /// </summary>
    public long? ParentId { get; set; }

    /// <summary>
    /// آدرس فروشگاه
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// کدپستی فروشگاه
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// تلفن ثابت فروشگاه
    /// </summary>
    public string? Tel { get; set; }

    /// <summary>
    /// فکس فروشگاه
    /// </summary>
    public string? Fax { get; set; }

    /// <summary>
    /// ایمیل فروشگاه
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// نوع شخص (T : حقیقی  F : حقوقی)
    /// </summary>
    public bool PersonType { get; set; }

    /// <summary>
    /// کد ملی فروشگاه
    /// </summary>
    public string? NationalCode { get; set; }

    /// <summary>
    /// شناسه ملی فروشگاه
    /// </summary>
    public string? NationalId { get; set; }

    /// <summary>
    /// کد اقتصادی فروشگاه
    /// </summary>
    public string? EconomicalNumber { get; set; }

    /// <summary>
    /// شماره ثبت فروشگاه
    /// </summary>
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// شناسه خارجی جدول تصاویر برای لوگو فروشگاه
    /// </summary>
    public long? BranchLogoId { get; set; }

    /// <summary>
    /// توضیحات مرتبط با فروشگاه
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاریخ ایجاد فروشگاه
    /// </summary>
    public DateTime CreateDate { get; set; }

    public virtual ICollection<AccountTitle> AccountTitles { get; set; } = new List<AccountTitle>();

    public virtual ICollection<Bank> Banks { get; set; } = new List<Bank>();

    public virtual ICollection<BeginningBalance> BeginningBalances { get; set; } = new List<BeginningBalance>();

    public virtual Medium? BranchLogo { get; set; }

    public virtual ICollection<BranchPlan> BranchPlans { get; set; } = new List<BranchPlan>();

    public virtual ICollection<BranchUser> BranchUsers { get; set; } = new List<BranchUser>();

    public virtual ICollection<BuyInvoice> BuyInvoices { get; set; } = new List<BuyInvoice>();

    public virtual ICollection<CashDesk> CashDesks { get; set; } = new List<CashDesk>();

    public virtual ICollection<ChequeBook> ChequeBooks { get; set; } = new List<ChequeBook>();

    public virtual City? City { get; set; }

    public virtual ICollection<FinancialPeriod> FinancialPeriods { get; set; } = new List<FinancialPeriod>();

    public virtual ICollection<GroupPerson> GroupPeople { get; set; } = new List<GroupPerson>();

    public virtual ICollection<LockedDocument> LockedDocuments { get; set; } = new List<LockedDocument>();

    public virtual ICollection<PaymentRequest> PaymentRequests { get; set; } = new List<PaymentRequest>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual ICollection<PersonBeginningBalance> PersonBeginningBalances { get; set; } = new List<PersonBeginningBalance>();

    public virtual ICollection<ProductGroup> ProductGroups { get; set; } = new List<ProductGroup>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Province? Province { get; set; }

    public virtual ICollection<Reason> Reasons { get; set; } = new List<Reason>();

    public virtual ICollection<Receive> Receives { get; set; } = new List<Receive>();

    public virtual ICollection<SaleInvoice> SaleInvoices { get; set; } = new List<SaleInvoice>();

    public virtual ICollection<Template> Templates { get; set; } = new List<Template>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();

    public virtual ICollection<WarehouseMoveing> WarehouseMoveings { get; set; } = new List<WarehouseMoveing>();

    public virtual ICollection<WarehouseStock> WarehouseStocks { get; set; } = new List<WarehouseStock>();

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
