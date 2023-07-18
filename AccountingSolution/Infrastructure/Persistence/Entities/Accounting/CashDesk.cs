using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات صندوق استفاده می شود
/// </summary>
public partial class CashDesk
{
    /// <summary>
    /// شناسه جدول CashDesk
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// عنوان صندوق
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// کد صندوق
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه خارجی جدول User
    /// </summary>
    public long? UserId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<PaymentRequest> PaymentRequests { get; set; } = new List<PaymentRequest>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Receive> Receives { get; set; } = new List<Receive>();

    public virtual User? User { get; set; }
}
