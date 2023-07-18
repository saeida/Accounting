using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات  مربوط به حساب های بانکی هر کسب و کار استفاده می شود
/// </summary>
public partial class Bank
{
    /// <summary>
    /// شناسه جدول Bank
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// عنوان حساب بانکی
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// کد حساب بانکی
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// شماره حساب
    /// </summary>
    public string? AccountNumber { get; set; }

    /// <summary>
    /// شماره شبا
    /// </summary>
    public string? ShebaNumber { get; set; }

    /// <summary>
    /// شماره کارت
    /// </summary>
    public string? CardNumber { get; set; }

    /// <summary>
    /// به درگاه بانکی متصل است؟
    /// </summary>
    public bool IsBankGetway { get; set; }

    /// <summary>
    /// به کارتخوان متصل است؟
    /// </summary>
    public bool IsBankCardReader { get; set; }

    /// <summary>
    /// عنوان شعبه بانک
    /// </summary>
    public string? BankBranch { get; set; }

    /// <summary>
    /// کد شعبه بانک
    /// </summary>
    public string? BankBranchCode { get; set; }

    /// <summary>
    /// آدرس بانک
    /// </summary>
    public string? BankAddress { get; set; }

    /// <summary>
    /// تلفن بانک
    /// </summary>
    public string? BankTel { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<ChequeBook> ChequeBooks { get; set; } = new List<ChequeBook>();

    public virtual ICollection<ChequeTurnover> ChequeTurnovers { get; set; } = new List<ChequeTurnover>();

    public virtual ICollection<PaymentCommand> PaymentCommands { get; set; } = new List<PaymentCommand>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<ReceiveDetail> ReceiveDetails { get; set; } = new List<ReceiveDetail>();
}
