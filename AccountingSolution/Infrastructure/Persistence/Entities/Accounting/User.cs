using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات کاربران نرم افزار و هر فروشگاه استفاده می شود . ممکن است برخی کاربران در چند فروشگاه امکان ورود داشته باشند
/// </summary>
public partial class User
{
    /// <summary>
    /// شناسه جدول User
    /// </summary>
    public long Id { get; set; }


    /// <summary>
    /// نام کاربری
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    ///  موبایل
    /// </summary>
    public string? Mobile { get; set; }

    /// <summary>
    ///  ایمیل کاربر
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// کلمه عبور 
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// نام کاربر
    /// </summary>
    public string Fname { get; set; } = null!;

    /// <summary>
    /// نام خانوادگی کاربر
    /// </summary>
    public string Lname { get; set; } = null!;

    /// <summary>
    /// وضعیت فعال بودن کاربر
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>
    /// تاریخ ایجاد کاربر
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// آخرین ورود کاربر - اگر هنوز لاگین نکرده ، تاریخ 1900-01-01 درج شود
    /// </summary>
    public DateTime LastLoginDate { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Roles
    /// </summary>
    public long RoleId { get; set; }

    public virtual ICollection<BeginningBalanceDetail> BeginningBalanceDetails { get; set; } = new List<BeginningBalanceDetail>();

    public virtual ICollection<BeginningBalance> BeginningBalances { get; set; } = new List<BeginningBalance>();

    public virtual ICollection<BranchUser> BranchUsers { get; set; } = new List<BranchUser>();

    public virtual ICollection<BuyInvoiceDetail> BuyInvoiceDetails { get; set; } = new List<BuyInvoiceDetail>();

    public virtual ICollection<BuyInvoice> BuyInvoices { get; set; } = new List<BuyInvoice>();

    public virtual ICollection<CashDesk> CashDesks { get; set; } = new List<CashDesk>();

    public virtual ICollection<ChequeBook> ChequeBooks { get; set; } = new List<ChequeBook>();

    public virtual ICollection<ChequeTurnover> ChequeTurnovers { get; set; } = new List<ChequeTurnover>();

    public virtual ICollection<PaymentCommand> PaymentCommandCommandCreationUsers { get; set; } = new List<PaymentCommand>();

    public virtual ICollection<PaymentCommand> PaymentCommandSodorCreationUsers { get; set; } = new List<PaymentCommand>();

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();

    public virtual ICollection<PaymentRequest> PaymentRequests { get; set; } = new List<PaymentRequest>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual ICollection<ReceiveDetail> ReceiveDetails { get; set; } = new List<ReceiveDetail>();

    public virtual ICollection<Receive> Receives { get; set; } = new List<Receive>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<SaleInvoiceDetail> SaleInvoiceDetails { get; set; } = new List<SaleInvoiceDetail>();

    public virtual ICollection<SaleInvoice> SaleInvoices { get; set; } = new List<SaleInvoice>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<VoucherDetail> VoucherDetails { get; set; } = new List<VoucherDetail>();

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();

    public virtual ICollection<WarehouseMoveingDetail> WarehouseMoveingDetails { get; set; } = new List<WarehouseMoveingDetail>();

    public virtual ICollection<WarehouseMoveing> WarehouseMoveings { get; set; } = new List<WarehouseMoveing>();
}
