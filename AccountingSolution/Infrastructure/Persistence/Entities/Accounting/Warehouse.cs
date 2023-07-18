using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Accounting;

/// <summary>
/// جهت نگهداری اطلاعات انبار یا فروشگاه استفاده می شود
/// </summary>
public partial class Warehouse
{
    /// <summary>
    /// شناسه جدول Warehouse
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// عنوان انبار یا فروشگاه
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// کد انبار یا فروشگاه
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    public virtual ICollection<BeginningBalanceDetail> BeginningBalanceDetails { get; set; } = new List<BeginningBalanceDetail>();

    public virtual ICollection<BeginningBalance> BeginningBalances { get; set; } = new List<BeginningBalance>();

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<BuyInvoiceDetail> BuyInvoiceDetails { get; set; } = new List<BuyInvoiceDetail>();

    public virtual ICollection<BuyInvoice> BuyInvoices { get; set; } = new List<BuyInvoice>();

    public virtual ICollection<SaleInvoiceDetail> SaleInvoiceDetails { get; set; } = new List<SaleInvoiceDetail>();

    public virtual ICollection<SaleInvoice> SaleInvoices { get; set; } = new List<SaleInvoice>();

    public virtual ICollection<WarehouseMoveingDetail> WarehouseMoveingDetailWarehouseIns { get; set; } = new List<WarehouseMoveingDetail>();

    public virtual ICollection<WarehouseMoveingDetail> WarehouseMoveingDetailWarehouseOuts { get; set; } = new List<WarehouseMoveingDetail>();

    public virtual ICollection<WarehouseMoveing> WarehouseMoveingWarehouseIns { get; set; } = new List<WarehouseMoveing>();

    public virtual ICollection<WarehouseMoveing> WarehouseMoveingWarehouseOuts { get; set; } = new List<WarehouseMoveing>();

    public virtual ICollection<WarehouseStock> WarehouseStocks { get; set; } = new List<WarehouseStock>();
}
