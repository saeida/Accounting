using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات اشخاص برای هر کسب و کار استفاده می شود
/// </summary>
public partial class Person
{
    /// <summary>
    /// شناسه جدول Person
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// کد شناسایی شخص
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// شناسه خارجی جدول GroupPerson
    /// </summary>
    public long? GroupPersonId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Title
    /// </summary>
    public long? TitleId { get; set; }

    /// <summary>
    /// نام شخص
    /// </summary>
    public string? Fname { get; set; }

    /// <summary>
    /// نام خانوادگی شخص
    /// </summary>
    public string? Lname { get; set; }

    /// <summary>
    /// وضعیت فعالیت مشتری
    /// </summary>
    public byte State { get; set; }

    /// <summary>
    /// شخص آیا کارمند است
    /// </summary>
    public bool IsEmployee { get; set; }

    /// <summary>
    /// شخص آیا مشتری است
    /// </summary>
    public bool IsCustomer { get; set; }

    /// <summary>
    /// شخص آیا فروشنده است
    /// </summary>
    public bool IsSeller { get; set; }

    /// <summary>
    /// شخص آیا بازاریاب است
    /// </summary>
    public bool IsVisitor { get; set; }

    /// <summary>
    /// شخص آیا تنخواه گردان است
    /// </summary>
    public bool IsSlanderer { get; set; }

    /// <summary>
    /// شخص آیا گیرنده است
    /// </summary>
    public bool IsReceiver { get; set; }

    /// <summary>
    /// شخص آیا نماینده است
    /// </summary>
    public bool IsAgent { get; set; }

    /// <summary>
    /// درصد حق الزحمه بازاریاب
    /// </summary>
    public decimal? VisitorPercentage { get; set; }

    /// <summary>
    /// تلفن شخص
    /// </summary>
    public string? Tel { get; set; }

    /// <summary>
    /// موبایل شخص
    /// </summary>
    public string? Mobile { get; set; }

    /// <summary>
    /// فکس شخص
    /// </summary>
    public string? Fax { get; set; }

    /// <summary>
    /// ایمیل شخص
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Province
    /// </summary>
    public long? ProvinceId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول City
    /// </summary>
    public long? CityId { get; set; }

    /// <summary>
    /// آدرس شخص
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// کدپستی شخص
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// شناسه جدول خارجی تصویر شخص
    /// </summary>
    public long? PictureId { get; set; }

    /// <summary>
    /// نوع شخص (T : حقیقی - F: حقوقی)
    /// </summary>
    public bool PersonType { get; set; }

    /// <summary>
    /// کدملی شخص
    /// </summary>
    public string? NationalCode { get; set; }

    /// <summary>
    /// شناسه ملی شخص
    /// </summary>
    public string? NationalId { get; set; }

    /// <summary>
    /// شماره اقتصادی شخص
    /// </summary>
    public string? EconomicalNumber { get; set; }

    /// <summary>
    /// شماره ثبت شرکت 
    /// </summary>
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// نام شرکت
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاریخ ایجاد شخص
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول User
    /// </summary>
    public long CreateUserId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<BuyInvoice> BuyInvoices { get; set; } = new List<BuyInvoice>();

    public virtual City? City { get; set; }

    public virtual User CreateUser { get; set; } = null!;

    public virtual ICollection<DeactiveReason> DeactiveReasons { get; set; } = new List<DeactiveReason>();

    public virtual GroupPerson? GroupPerson { get; set; }

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();

    public virtual ICollection<PaymentRequest> PaymentRequests { get; set; } = new List<PaymentRequest>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<PersonAgent> PersonAgentAgents { get; set; } = new List<PersonAgent>();

    public virtual ICollection<PersonAgent> PersonAgentPeople { get; set; } = new List<PersonAgent>();

    public virtual ICollection<PersonBeginningBalance> PersonBeginningBalances { get; set; } = new List<PersonBeginningBalance>();

    public virtual Medium? Picture { get; set; }

    public virtual Province? Province { get; set; }

    public virtual ICollection<Receive> Receives { get; set; } = new List<Receive>();

    public virtual ICollection<SaleInvoice> SaleInvoiceCustomerNavigations { get; set; } = new List<SaleInvoice>();

    public virtual ICollection<SaleInvoice> SaleInvoiceVisitorNavigations { get; set; } = new List<SaleInvoice>();

    public virtual Title? Title { get; set; }

    public virtual ICollection<VoucherDetail> VoucherDetails { get; set; } = new List<VoucherDetail>();
}
