using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.Samina;

/// <summary>
/// جهت نگهداری اطلاعات کالا استفاده می شود
/// </summary>
public partial class Product
{
    /// <summary>
    /// شناسه جدول Product
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Branch
    /// </summary>
    public long BranchId { get; set; }

    /// <summary>
    /// عنوان کالا
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// عنوان دوم کالا
    /// </summary>
    public string? FactorTitle { get; set; }

    /// <summary>
    /// کد کالا
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// بارکد کالا
    /// </summary>
    public string? BarCode { get; set; }

    /// <summary>
    /// شناسه خارجی جدول ProductGroup - گروه بندی کالا
    /// </summary>
    public long? ProductGroupId { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Unit - واحد اصلی
    /// </summary>
    public long? MainUnit { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Unit - واحد فرعی و دوم
    /// </summary>
    public long? SecondUnit { get; set; }

    /// <summary>
    /// رابطه مقداری واحد فرعی و اصلی
    /// </summary>
    public decimal? SecondUnitCount { get; set; }

    /// <summary>
    /// نقطه سفارش کالا
    /// </summary>
    public decimal? OrderPoint { get; set; }

    /// <summary>
    /// مقدار مجاز خرید جهت سفارش کالا
    /// </summary>
    public decimal? BuyMaxOrder { get; set; }

    /// <summary>
    /// مقدار موجودی اولیه کالا
    /// </summary>
    public decimal? InitialBalance { get; set; }

    /// <summary>
    /// مبلغ موجودی اولیه کالا
    /// </summary>
    public decimal? InitialPrice { get; set; }

    /// <summary>
    /// آیا کالا است یا خدمات؟
    /// </summary>
    public bool? IsProduct { get; set; }

    /// <summary>
    /// آیا قابل فروش است؟
    /// </summary>
    public bool? IsSalable { get; set; }

    /// <summary>
    /// آیا قابل استفاده در سایت می باشد؟
    /// </summary>
    public bool IsUseStore { get; set; }

    /// <summary>
    /// روش قیمت گذاری قیمت تمام شده انبار
    /// </summary>
    public byte WarehousePricingMethod { get; set; }

    /// <summary>
    /// روش قیمت گذاری فروش کالا
    /// </summary>
    public byte PricingMethod { get; set; }

    /// <summary>
    /// درصد مبلغ فروش کالا بر اساس آخرین قیمت خرید
    /// </summary>
    public decimal? SalePricePercent { get; set; }

    /// <summary>
    /// درصد مبلغ فروش عمده کالا بر اساس آخرین قیمت خرید
    /// </summary>
    public decimal? WholePricePercent { get; set; }

    /// <summary>
    /// درصد مبلغ فروش به نماینده کالا بر اساس آخرین قیمت خرید
    /// </summary>
    public decimal? AgentPricePercent { get; set; }

    /// <summary>
    /// مجاز به دریافت ارزش افزوده در فروش؟
    /// </summary>
    public bool? IsSaleTaxable { get; set; }

    /// <summary>
    /// مجاز به دریافت ارزش افزوده در خرید؟
    /// </summary>
    public bool? IsBuyTaxable { get; set; }

    /// <summary>
    /// درصد تخفیف کالا
    /// </summary>
    public decimal? DiscountPercent { get; set; }

    /// <summary>
    /// شناسه خارجی جدول Media
    /// </summary>
    public long? MediaId { get; set; }

    /// <summary>
    /// توضیحات کالا
    /// </summary>
    public string? Description { get; set; }

    public virtual ICollection<BeginningBalanceDetail> BeginningBalanceDetails { get; set; } = new List<BeginningBalanceDetail>();

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<BuyInvoiceDetail> BuyInvoiceDetails { get; set; } = new List<BuyInvoiceDetail>();

    public virtual Medium? Media { get; set; }

    public virtual ProductGroup? ProductGroup { get; set; }

    public virtual ICollection<SaleInvoiceDetail> SaleInvoiceDetails { get; set; } = new List<SaleInvoiceDetail>();

    public virtual ICollection<WarehouseMoveingDetail> WarehouseMoveingDetails { get; set; } = new List<WarehouseMoveingDetail>();

    public virtual ICollection<WarehouseStock> WarehouseStocks { get; set; } = new List<WarehouseStock>();
}
