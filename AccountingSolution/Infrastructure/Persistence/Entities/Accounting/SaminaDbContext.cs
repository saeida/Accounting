using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Entities.Accounting;

public partial class SaminaDbContext : DbContext
{
    public SaminaDbContext()
    {
    }

    public SaminaDbContext(DbContextOptions<SaminaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessControlList> AccessControlLists { get; set; }

    public virtual DbSet<AccountTitle> AccountTitles { get; set; }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<BeginningBalance> BeginningBalances { get; set; }

    public virtual DbSet<BeginningBalanceDetail> BeginningBalanceDetails { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<BranchPlan> BranchPlans { get; set; }

    public virtual DbSet<BranchUser> BranchUsers { get; set; }

    public virtual DbSet<BuyInvoice> BuyInvoices { get; set; }

    public virtual DbSet<BuyInvoiceDetail> BuyInvoiceDetails { get; set; }

    public virtual DbSet<CashDesk> CashDesks { get; set; }

    public virtual DbSet<ChequeBook> ChequeBooks { get; set; }

    public virtual DbSet<ChequeTurnover> ChequeTurnovers { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<DeactiveReason> DeactiveReasons { get; set; }

    public virtual DbSet<FinancialPeriod> FinancialPeriods { get; set; }

    public virtual DbSet<GroupPerson> GroupPeople { get; set; }

    public virtual DbSet<LockedDocument> LockedDocuments { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentCommand> PaymentCommands { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<PaymentRequest> PaymentRequests { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonAgent> PersonAgents { get; set; }

    public virtual DbSet<PersonBeginningBalance> PersonBeginningBalances { get; set; }

    public virtual DbSet<Plan> Plans { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductGroup> ProductGroups { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<PublicEnum> PublicEnums { get; set; }

    public virtual DbSet<Reason> Reasons { get; set; }

    public virtual DbSet<Receive> Receives { get; set; }

    public virtual DbSet<ReceiveDetail> ReceiveDetails { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SaleInvoice> SaleInvoices { get; set; }

    public virtual DbSet<SaleInvoiceDetail> SaleInvoiceDetails { get; set; }

    public virtual DbSet<Template> Templates { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    public virtual DbSet<VoucherDetail> VoucherDetails { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WarehouseMoveing> WarehouseMoveings { get; set; }

    public virtual DbSet<WarehouseMoveingDetail> WarehouseMoveingDetails { get; set; }

    public virtual DbSet<WarehouseStock> WarehouseStocks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-LJH87UL;Initial Catalog=SaminaDB;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Persian_100_BIN");

        modelBuilder.Entity<AccessControlList>(entity =>
        {
            entity.ToTable("AccessControlList", "user", tb => tb.HasComment("جهت نگهداری سطح دسترسی هر نقش استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول AccessControlList");
            entity.Property(e => e.PermissionId)
                .HasComment("شناسه خارجی جدول Permission")
                .HasColumnName("Permission_Id");
            entity.Property(e => e.RoleId)
                .HasComment("شناسه خارجی جدول Roles")
                .HasColumnName("Role_Id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AccessControlLists)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccessControlList_Permissions");

            entity.HasOne(d => d.Role).WithMany(p => p.AccessControlLists)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccessControlList_Roles");
        });

        modelBuilder.Entity<AccountTitle>(entity =>
        {
            entity.ToTable("AccountTitle", "basic", tb => tb.HasComment("جهت نگهداری اطلاعات سرفصل های حسابداری استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول AccountTitle");
            entity.Property(e => e.AccountGroup).HasComment("شناسه خارجی جدول PublicEnum با کد 06");
            entity.Property(e => e.AccountLevel).HasComment("حساب در چه سطحی است؟");
            entity.Property(e => e.AccountNature).HasComment("ماهیت حساب");
            entity.Property(e => e.AccountType).HasComment("نوع حساب");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasComment("کد سرفصل حسابداری");
            entity.Property(e => e.FullCode)
                .HasMaxLength(100)
                .HasComment("کد کامل شامل کدهای پدر سرفصل حسابداری");
            entity.Property(e => e.ParentId)
                .HasComment("شناسه پدر سرفصل حسابداری")
                .HasColumnName("Parent_Id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasComment("عنوان سرفصل حسابداری");

            entity.HasOne(d => d.Branch).WithMany(p => p.AccountTitles)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountTitle_Branch");
        });

        modelBuilder.Entity<Bank>(entity =>
        {
            entity.ToTable("Bank", "basic", tb => tb.HasComment("جهت نگهداری اطلاعات  مربوط به حساب های بانکی هر کسب و کار استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Bank");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(24)
                .HasComment("شماره حساب");
            entity.Property(e => e.BankAddress)
                .HasMaxLength(200)
                .HasComment("آدرس بانک");
            entity.Property(e => e.BankBranch)
                .HasMaxLength(30)
                .HasComment("عنوان شعبه بانک");
            entity.Property(e => e.BankBranchCode)
                .HasMaxLength(5)
                .HasComment("کد شعبه بانک");
            entity.Property(e => e.BankTel)
                .HasMaxLength(8)
                .HasComment("تلفن بانک");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(16)
                .HasComment("شماره کارت");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .HasComment("کد حساب بانکی");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.IsBankCardReader).HasComment("به کارتخوان متصل است؟");
            entity.Property(e => e.IsBankGetway).HasComment("به درگاه بانکی متصل است؟");
            entity.Property(e => e.ShebaNumber)
                .HasMaxLength(24)
                .HasComment("شماره شبا");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasComment("عنوان حساب بانکی");

            entity.HasOne(d => d.Branch).WithMany(p => p.Banks)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bank_Branch");
        });

        modelBuilder.Entity<BeginningBalance>(entity =>
        {
            entity.ToTable("BeginningBalance", "warehouse", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به موجودی ابتدای دوره کالا استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول BeginningBalance");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد فاکتور")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.FinancialPeriodId)
                .HasComment("شناسه خارجی جدول FinancialPeriod")
                .HasColumnName("FinancialPeriod_Id");
            entity.Property(e => e.InvoiceDate)
                .HasComment("تاریخ فاکتور")
                .HasColumnType("datetime");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(10)
                .HasComment("شماره فاکتور");
            entity.Property(e => e.WarehouseId)
                .HasComment("شناسه خارجی جدول Warehouse")
                .HasColumnName("Warehouse_Id");

            entity.HasOne(d => d.Branch).WithMany(p => p.BeginningBalances)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BeginningBalance_Branch");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.BeginningBalances)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BeginningBalance_User");

            entity.HasOne(d => d.FinancialPeriod).WithMany(p => p.BeginningBalances)
                .HasForeignKey(d => d.FinancialPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BeginningBalance_FinancialPeriod");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.BeginningBalances)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK_BeginningBalance_Warehouse");
        });

        modelBuilder.Entity<BeginningBalanceDetail>(entity =>
        {
            entity.ToTable("BeginningBalanceDetail", "warehouse", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به جزییات موجودی ابتدای دوره کالا استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول BeginningBalanceDetail");
            entity.Property(e => e.BeginningBalanceId)
                .HasComment("شناسه خارجی جدول BeginningBalance")
                .HasColumnName("BeginningBalance_Id");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد جزییات فاکتور")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.FixedPrice)
                .HasDefaultValueSql("((0))")
                .HasComment("قیمت تمام شده کالا")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.MainAmount)
                .HasComment("مقدار اصلی")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Price)
                .HasComment("مبلغ واحد")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ProductId)
                .HasComment("شناسه خارجی جدول Product")
                .HasColumnName("Product_Id");
            entity.Property(e => e.RowNumber).HasComment("شماره ردیف جزییات هر سند");
            entity.Property(e => e.SecondAmount)
                .HasDefaultValueSql("((0))")
                .HasComment("مقدار فرعی")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.WarehouseId)
                .HasComment("شناسه خارجی جدول Warehouse")
                .HasColumnName("Warehouse_Id");

            entity.HasOne(d => d.BeginningBalance).WithMany(p => p.BeginningBalanceDetails)
                .HasForeignKey(d => d.BeginningBalanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BeginningBalanceDetail_BeginningBalance");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.BeginningBalanceDetails)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BeginningBalanceDetail_User");

            entity.HasOne(d => d.Product).WithMany(p => p.BeginningBalanceDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BeginningBalanceDetail_Product");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.BeginningBalanceDetails)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK_BeginningBalanceDetail_Warehouse");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.ToTable("Branch", "manage", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به مدیر کسب و کار و یا فروشگاه با ساختار درختی و سلسله مراتبی در نظر گرفته می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Branch");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasComment("آدرس فروشگاه");
            entity.Property(e => e.BranchLogoId)
                .HasComment("شناسه خارجی جدول تصاویر برای لوگو فروشگاه")
                .HasColumnName("BranchLogo_Id");
            entity.Property(e => e.CityId)
                .HasComment("شناسه خارجی شهر محل فروشگاه")
                .HasColumnName("City_Id");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد فروشگاه")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات مرتبط با فروشگاه");
            entity.Property(e => e.EconomicalNumber)
                .HasMaxLength(12)
                .HasComment("کد اقتصادی فروشگاه");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasComment("ایمیل فروشگاه");
            entity.Property(e => e.Fax)
                .HasMaxLength(8)
                .HasComment("فکس فروشگاه");
            entity.Property(e => e.NationalCode)
                .HasMaxLength(10)
                .HasComment("کد ملی فروشگاه");
            entity.Property(e => e.NationalId)
                .HasMaxLength(11)
                .HasComment("شناسه ملی فروشگاه");
            entity.Property(e => e.ParentId).HasComment("شناسه پدر و بالا سری فروشگاه  - اگر خالی بود ، یعنی پدر هست و اگر پر بود یعنی فرزند");
            entity.Property(e => e.PersonType).HasComment("نوع شخص (T : حقیقی  F : حقوقی)");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasComment("کدپستی فروشگاه");
            entity.Property(e => e.ProvinceId)
                .HasComment("شناسه خارجی استان محل فروشگاه")
                .HasColumnName("Province_Id");
            entity.Property(e => e.RegistrationNumber)
                .HasMaxLength(12)
                .HasComment("شماره ثبت فروشگاه");
            entity.Property(e => e.Tel)
                .HasMaxLength(8)
                .HasComment("تلفن ثابت فروشگاه");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasComment("نام کسب و کار یا فروشگاه");

            entity.HasOne(d => d.BranchLogo).WithMany(p => p.Branches)
                .HasForeignKey(d => d.BranchLogoId)
                .HasConstraintName("FK_Branch_Media");

            entity.HasOne(d => d.City).WithMany(p => p.Branches)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Branch_City");

            entity.HasOne(d => d.Province).WithMany(p => p.Branches)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("FK_Branch_Province");
        });

        modelBuilder.Entity<BranchPlan>(entity =>
        {
            entity.ToTable("BranchPlan", "manage", tb => tb.HasComment("جهت نگهداری پلن های خریداری شده برای هر فروشگاه استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول BranchPlan");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.BuyPrice)
                .HasComment("قیمت پلن خریداری شده")
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد پلن")
                .HasColumnType("datetime");
            entity.Property(e => e.DiscountedPrice)
                .HasDefaultValueSql("((0))")
                .HasComment("تخفیف پلن خریداری شده")
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.EndDate)
                .HasComment("تاریخ پایان پلن")
                .HasColumnType("datetime");
            entity.Property(e => e.PayBankId)
                .HasComment("شناسه خارجی جدول بانک درگاه پرداخت")
                .HasColumnName("PayBank_Id");
            entity.Property(e => e.PayCode)
                .HasMaxLength(30)
                .HasComment("کد پیگیری برگشتی از درگاه پرداخت");
            entity.Property(e => e.PayDate)
                .HasComment("تاریخ پرداخت در درگاه پرداخت")
                .HasColumnType("datetime");
            entity.Property(e => e.PlanId)
                .HasComment("شناسه خارجی جدول Plan")
                .HasColumnName("Plan_Id");
            entity.Property(e => e.StartDate)
                .HasComment("تاریخ شروع پلن")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Branch).WithMany(p => p.BranchPlans)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BranchPlan_Branch");

            entity.HasOne(d => d.PayBank).WithMany(p => p.BranchPlans)
                .HasForeignKey(d => d.PayBankId)
                .HasConstraintName("FK_BranchPlan_PublicEnum");

            entity.HasOne(d => d.Plan).WithMany(p => p.BranchPlans)
                .HasForeignKey(d => d.PlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BranchPlan_Plan");
        });

        modelBuilder.Entity<BranchUser>(entity =>
        {
            entity.ToTable("BranchUser", "user", tb => tb.HasComment("جهت نگهداری ارتباط کاربر و کسب و کار نرم افزار استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول BranchUser");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.IsDefault).HasComment("کسب و کار پیش فرض هر کاربر");
            entity.Property(e => e.UserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("User_Id");

            entity.HasOne(d => d.Branch).WithMany(p => p.BranchUsers)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BranchUser_Branch");

            entity.HasOne(d => d.User).WithMany(p => p.BranchUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BranchUser_User");
        });

        modelBuilder.Entity<BuyInvoice>(entity =>
        {
            entity.ToTable("BuyInvoice", "warehouse", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به خرید کالا استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول BuyInvoice");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد فاکتور")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.FinancialPeriodId)
                .HasComment("شناسه خارجی جدول FinancialPeriod")
                .HasColumnName("FinancialPeriod_Id");
            entity.Property(e => e.InvoiceDate)
                .HasComment("تاریخ فاکتور")
                .HasColumnType("datetime");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(10)
                .HasComment("شماره فاکتور");
            entity.Property(e => e.InvoiceType).HasComment("نوع فاکتور");
            entity.Property(e => e.RelatedInvoiceNumber)
                .HasMaxLength(10)
                .HasComment("شماره فاکتور برگشت خرید");
            entity.Property(e => e.Saler).HasComment("شناسه خارجی جدول Person - فروشنده");
            entity.Property(e => e.SalerInvoiceDate)
                .HasComment("تاریخ فاکتور مربوط به فروشنده")
                .HasColumnType("datetime");
            entity.Property(e => e.SalerInvoiceNumber)
                .HasMaxLength(10)
                .HasComment("شماره فاکتور مربوط به فروشنده");
            entity.Property(e => e.TotalDiscountAmount)
                .HasDefaultValueSql("((0))")
                .HasComment("مبلغ تخفیف که روی کل فاکتور ثبت می شود")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.TotalDiscountPercent)
                .HasDefaultValueSql("((0))")
                .HasComment("درصد تخفیف که روی کل فاکتور ثبت می شود")
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TransportCost)
                .HasDefaultValueSql("((0))")
                .HasComment("هزینه حمل کالا")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.WarehouseId)
                .HasComment("شناسه خارجی جدول Warehouse")
                .HasColumnName("Warehouse_Id");

            entity.HasOne(d => d.Branch).WithMany(p => p.BuyInvoices)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BuyInvoice_Branch");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.BuyInvoices)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BuyInvoice_User");

            entity.HasOne(d => d.FinancialPeriod).WithMany(p => p.BuyInvoices)
                .HasForeignKey(d => d.FinancialPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BuyInvoice_FinancialPeriod");

            entity.HasOne(d => d.SalerNavigation).WithMany(p => p.BuyInvoices)
                .HasForeignKey(d => d.Saler)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BuyInvoice_Person");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.BuyInvoices)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK_BuyInvoice_Warehouse");
        });

        modelBuilder.Entity<BuyInvoiceDetail>(entity =>
        {
            entity.ToTable("BuyInvoiceDetail", "warehouse", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به جزییات خرید کالا استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول BuyInvoiceDetail");
            entity.Property(e => e.BuyInvoiceId)
                .HasComment("شناسه خارجی جدول BuyInvoice")
                .HasColumnName("BuyInvoice_Id");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد جزییات فاکتور")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.Discount)
                .HasDefaultValueSql("((0))")
                .HasComment("تخفیف مربوط به هر کالا")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.DiscountPercent)
                .HasDefaultValueSql("((0))")
                .HasComment("درصد تخفیف مربوط به هر کالا")
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.FixedPrice)
                .HasDefaultValueSql("((0))")
                .HasComment("قیمت تمام شده کالا")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.MainAmount)
                .HasComment("مقدار اصلی")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Price)
                .HasComment("مبلغ واحد")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ProductId)
                .HasComment("شناسه خارجی جدول Product")
                .HasColumnName("Product_Id");
            entity.Property(e => e.RowNumber).HasComment("شماره ردیف جزییات هر سند");
            entity.Property(e => e.SecondAmount)
                .HasDefaultValueSql("((0))")
                .HasComment("مقدار فرعی")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Vat1)
                .HasDefaultValueSql("((0))")
                .HasComment("مبلغ مالیات بر ارزش افزوده")
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Vat2)
                .HasDefaultValueSql("((0))")
                .HasComment("مبلغ عوارض ارزش افزوده")
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.WarehouseId)
                .HasComment("شناسه خارجی جدول Warehouse")
                .HasColumnName("Warehouse_Id");

            entity.HasOne(d => d.BuyInvoice).WithMany(p => p.BuyInvoiceDetails)
                .HasForeignKey(d => d.BuyInvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BuyInvoiceDetail_BuyInvoice");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.BuyInvoiceDetails)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BuyInvoiceDetail_User");

            entity.HasOne(d => d.Product).WithMany(p => p.BuyInvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BuyInvoiceDetail_Product");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.BuyInvoiceDetails)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK_BuyInvoiceDetail_Warehouse");
        });

        modelBuilder.Entity<CashDesk>(entity =>
        {
            entity.ToTable("CashDesk", "basic", tb => tb.HasComment("جهت نگهداری اطلاعات صندوق استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول CashDesk");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .HasComment("کد صندوق");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasComment("عنوان صندوق");
            entity.Property(e => e.UserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("User_Id");

            entity.HasOne(d => d.Branch).WithMany(p => p.CashDesks)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CashDesk_Branch");

            entity.HasOne(d => d.User).WithMany(p => p.CashDesks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_CashDesk_User");
        });

        modelBuilder.Entity<ChequeBook>(entity =>
        {
            entity.ToTable("ChequeBook", "treasury", tb => tb.HasComment("جهت نگهداری و تعریف اطلاعات مربوط به دسته چک های دریافتی از بانک جهت پرداخت استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول ChequeBook");
            entity.Property(e => e.BankId)
                .HasComment("شناسه جدول Bank")
                .HasColumnName("Bank_Id");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .HasComment("کد دسته چک");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد رسید پرداخت")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.EndNumber)
                .HasMaxLength(10)
                .HasComment("آخرین شماره برگ در دسته چک");
            entity.Property(e => e.IssueDate)
                .HasComment("تاریخ صدور یا دریافت دسته چک از بانک")
                .HasColumnType("datetime");
            entity.Property(e => e.StartNumber)
                .HasMaxLength(10)
                .HasComment("اولین شماره برگ در دسته چک");
            entity.Property(e => e.Title)
                .HasMaxLength(60)
                .HasComment("عنوان دسته چک");

            entity.HasOne(d => d.Bank).WithMany(p => p.ChequeBooks)
                .HasForeignKey(d => d.BankId)
                .HasConstraintName("FK_ChequeBook_Bank");

            entity.HasOne(d => d.Branch).WithMany(p => p.ChequeBooks)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChequeBook_Branch");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.ChequeBooks)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChequeBook_User");
        });

        modelBuilder.Entity<ChequeTurnover>(entity =>
        {
            entity.ToTable("ChequeTurnover", "treasury", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط گردش اسناد و چک ها استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول ChequeTurnover");
            entity.Property(e => e.BankId)
                .HasComment("شناسه جدول Bank")
                .HasColumnName("Bank_Id");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد رسید پرداخت")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.ReceiveId)
                .HasComment("شناسه خارجی جدول Receive")
                .HasColumnName("Receive_Id");
            entity.Property(e => e.Serial)
                .HasMaxLength(10)
                .HasComment("شماره فیش یا ارجاع بابت واگذاری");
            entity.Property(e => e.Status).HasComment("وضعیت گردش");
            entity.Property(e => e.StatusDate)
                .HasComment("تاریخ ثبت گردش")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Bank).WithMany(p => p.ChequeTurnovers)
                .HasForeignKey(d => d.BankId)
                .HasConstraintName("FK_ChequeTurnover_Bank");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.ChequeTurnovers)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChequeTurnover_User");

            entity.HasOne(d => d.Receive).WithMany(p => p.ChequeTurnovers)
                .HasForeignKey(d => d.ReceiveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChequeTurnover_Receive");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City", "pub", tb => tb.HasComment("جهت نگهداری اطلاعات شهر های هر استان ها استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول City");
            entity.Property(e => e.ProvinceId)
                .HasComment("شناسه خارجی جدول Province")
                .HasColumnName("Province_Id");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .HasComment("عنوان شهر");

            entity.HasOne(d => d.Province).WithMany(p => p.Cities)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_Province");
        });

        modelBuilder.Entity<DeactiveReason>(entity =>
        {
            entity.ToTable("DeactiveReason", "basic", tb => tb.HasComment("جهت نگهداری اطلاعات غیر فعال کردن اضخاص و ممنوع المعامله کردن افراد استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول DeactiveReason");
            entity.Property(e => e.ActiveDate)
                .HasComment("تاریخ فعال کردن شخص")
                .HasColumnType("datetime");
            entity.Property(e => e.DeactiveDate)
                .HasComment("تاریخ غیرفعال کردن شخص")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.PersonId)
                .HasComment("شناسه خارجی جدول Person")
                .HasColumnName("Person_Id");
            entity.Property(e => e.ReasonId)
                .HasComment("شناسه خارجی جدول Reason")
                .HasColumnName("Reason_Id");

            entity.HasOne(d => d.Person).WithMany(p => p.DeactiveReasons)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeactiveReason_Person");

            entity.HasOne(d => d.Reason).WithMany(p => p.DeactiveReasons)
                .HasForeignKey(d => d.ReasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeactiveReason_Reason");
        });

        modelBuilder.Entity<FinancialPeriod>(entity =>
        {
            entity.ToTable("FinancialPeriod", "basic", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به سال مالی هر کسب و کار استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول FinancialPeriod");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.EndDate)
                .HasComment("تاریخ پایان سال مالی")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDefault).HasComment("آیا سال مالی پیش فرض است");
            entity.Property(e => e.StartDate)
                .HasComment("تاریخ شروع سال مالی")
                .HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasComment("عنوان سال مالی");

            entity.HasOne(d => d.Branch).WithMany(p => p.FinancialPeriods)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FinancialPeriod_Branch");
        });

        modelBuilder.Entity<GroupPerson>(entity =>
        {
            entity.ToTable("GroupPerson", "basic", tb => tb.HasComment("جهت نگهداری اطلاعات گروه بندی و دسته بندی های اشخاص استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول GroupPerson");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .HasComment("کد گروه شخص");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.EndFlag).HasComment("آیا آخرین لایه است یا خیر . یعنی بعد از این لایه ، اشخاص قرار می گیرند ");
            entity.Property(e => e.LevelNumber).HasComment("شماره لایه و سطح را مشخص میکند");
            entity.Property(e => e.ParentId).HasComment("شناسه پدر هر سطح از اشخاص");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .HasComment("عنوان گروه شخص");

            entity.HasOne(d => d.Branch).WithMany(p => p.GroupPeople)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupPerson_Branch");
        });

        modelBuilder.Entity<LockedDocument>(entity =>
        {
            entity.ToTable("LockedDocument", "acc", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط قفل کردن اسناد انبار و فروش و خزانه داری بر اساس سند حسابداری ثبت و لینک شده به آن ها استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول LockedDocument");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.DocumentType).HasComment("نوع رسید متصل شده به ردیف");
            entity.Property(e => e.DocumenttId).HasComment("شناسه رسید متصل شده به ردیف سند");
            entity.Property(e => e.FinancialPeriodId)
                .HasComment("شناسه خارجی جدول FinancialPeriod")
                .HasColumnName("FinancialPeriod_Id");
            entity.Property(e => e.VoucherId)
                .HasComment("شناسه خارجی جدول Voucher")
                .HasColumnName("Voucher_Id");

            entity.HasOne(d => d.Branch).WithMany(p => p.LockedDocuments)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LockedDocument_Branch");

            entity.HasOne(d => d.FinancialPeriod).WithMany(p => p.LockedDocuments)
                .HasForeignKey(d => d.FinancialPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LockedDocument_FinancialPeriod");

            entity.HasOne(d => d.Voucher).WithMany(p => p.LockedDocuments)
                .HasForeignKey(d => d.VoucherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LockedDocument_Voucher");
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.ToTable("Media", "basic", tb => tb.HasComment("جهت نگهداری کلیه تصاویر به شکل باینری در دیتابیس استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Media");
            entity.Property(e => e.Content1).HasComment("محتوای عکس بارگذاری شده شماره 1");
            entity.Property(e => e.Content2).HasComment("محتوای عکس بارگذاری شده شماره 2");
            entity.Property(e => e.Content3).HasComment("محتوای عکس بارگذاری شده شماره 3");
            entity.Property(e => e.Content4).HasComment("محتوای عکس بارگذاری شده شماره 4");
            entity.Property(e => e.Content5).HasComment("محتوای عکس بارگذاری شده شماره 5");
            entity.Property(e => e.GuideSize)
                .HasMaxLength(100)
                .HasComment("راهنمای سایزهای مختلف - جیسون");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.ToTable("Module", "user", tb => tb.HasComment("به منظور نگهداری عناوین فرم ها و بخش های سیستم که به آنها سطح دسترسی اعمال می شود استفاده میکنیم"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Module");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(70)
                .HasComment("عنوان فرم یا بخشی که سطح دسترسی به آن اعمال می شود");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment", "treasury", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط پرداخت کلیه وجوه و اسناد استفاده می شود . عموما بوسیله خرید کالا و یا برگشت فروش پر می شود "));

            entity.Property(e => e.Id).HasComment("شناسه جدول Payment");
            entity.Property(e => e.Amount)
                .HasComment("مبلغ پرداخت شده")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.BankBranch)
                .HasMaxLength(40)
                .HasComment("شعبه بانک");
            entity.Property(e => e.BankId)
                .HasComment("شناسه خارجی جدول Bank")
                .HasColumnName("Bank_Id");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.CashDeskId)
                .HasComment("شناسه خارجی جدول CashDesk")
                .HasColumnName("CashDesk_Id");
            entity.Property(e => e.ChequeAccountNumber)
                .HasMaxLength(24)
                .HasComment("شماره حساب سند / چک");
            entity.Property(e => e.ChequeBankId).HasComment("شناسه جدول PublicEnum با گروه 01");
            entity.Property(e => e.ChequeDate)
                .HasComment("تاریخ سند / چک")
                .HasColumnType("datetime");
            entity.Property(e => e.ChequeDescription)
                .HasMaxLength(100)
                .HasComment("توضیحات سند  / بابت چک");
            entity.Property(e => e.ChequeSerial)
                .HasMaxLength(20)
                .HasComment("سریال سند / چک");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد رسید پرداخت")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.FactorId).HasComment("شناسه فاکتور خرید یا برگشت فروش بدون ایجاد رابطه");
            entity.Property(e => e.FactorType).HasComment("نوع فاکتور");
            entity.Property(e => e.FinancialPeriodId)
                .HasComment("شناسه خارجی جدول FinancialPeriod")
                .HasColumnName("FinancialPeriod_Id");
            entity.Property(e => e.IsGarantyCheque)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("چک ضمانت است یا جاری؟");
            entity.Property(e => e.IsInClosedCash).HasComment("آیا صندوق بسته شده یا خیر؟");
            entity.Property(e => e.PaymentDate)
                .HasComment("تاریخ پرداخت")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentNumber)
                .HasMaxLength(10)
                .HasComment("شماره رسید پرداخت");
            entity.Property(e => e.PaymentType).HasComment("نوع پرداخت وجه را مشخص می کند");
            entity.Property(e => e.PersonId)
                .HasComment("شناسه خارجی جدول Person")
                .HasColumnName("Person_Id");
            entity.Property(e => e.ReceiptDate)
                .HasComment("تاریخ وصول چک")
                .HasColumnType("datetime");
            entity.Property(e => e.ReceiptStatus).HasComment("وضعیت وصول چک");

            entity.HasOne(d => d.Bank).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BankId)
                .HasConstraintName("FK_Payment_Bank");

            entity.HasOne(d => d.Branch).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Branch");

            entity.HasOne(d => d.CashDesk).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CashDeskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_CashDesk");

            entity.HasOne(d => d.ChequeBank).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ChequeBankId)
                .HasConstraintName("FK_Payment_PublicEnum");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_User");

            entity.HasOne(d => d.FinancialPeriod).WithMany(p => p.Payments)
                .HasForeignKey(d => d.FinancialPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_FinancialPeriod");

            entity.HasOne(d => d.Person).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Person");
        });

        modelBuilder.Entity<PaymentCommand>(entity =>
        {
            entity.ToTable("PaymentCommand", "treasury", tb => tb.HasComment("جهت نگهداری و تعریف اطلاعات مربوط به دستورات پرداخت  وصدور چک / تامین اعتبار استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول PaymentCommand");
            entity.Property(e => e.BankId)
                .HasComment("شناسه جدول Bank")
                .HasColumnName("Bank_Id");
            entity.Property(e => e.ChequeDate)
                .HasComment("تاریخ صدور چک")
                .HasColumnType("datetime");
            entity.Property(e => e.ChequeDescription)
                .HasMaxLength(100)
                .HasComment("بابت چک صادر شده");
            entity.Property(e => e.ChequeSerial)
                .HasMaxLength(20)
                .HasComment("سریال چک صادر شده");
            entity.Property(e => e.CommandCreationDate)
                .HasComment("تاریخ ایجاد دستور پرداخت")
                .HasColumnType("datetime");
            entity.Property(e => e.CommandCreationUserId)
                .HasComment("شناسه خارجی جدول User بابت دستور پرداخت")
                .HasColumnName("CommandCreationUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.PaymentRequestId)
                .HasComment("شناسه خارجی جدول PaymentRequest")
                .HasColumnName("PaymentRequest_Id");
            entity.Property(e => e.Priority).HasComment("اولویت صدور چک");
            entity.Property(e => e.SodorCreationDate)
                .HasComment("تاریخ ایجاد صدور چک")
                .HasColumnType("datetime");
            entity.Property(e => e.SodorCreationUserId)
                .HasComment("شناسه خارجی جدول User بابت صدور چک")
                .HasColumnName("SodorCreationUser_Id");

            entity.HasOne(d => d.Bank).WithMany(p => p.PaymentCommands)
                .HasForeignKey(d => d.BankId)
                .HasConstraintName("FK_PaymentCommand_Bank");

            entity.HasOne(d => d.CommandCreationUser).WithMany(p => p.PaymentCommandCommandCreationUsers)
                .HasForeignKey(d => d.CommandCreationUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentCommand_User");

            entity.HasOne(d => d.PaymentRequest).WithMany(p => p.PaymentCommands)
                .HasForeignKey(d => d.PaymentRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentCommand_PaymentRequest");

            entity.HasOne(d => d.SodorCreationUser).WithMany(p => p.PaymentCommandSodorCreationUsers)
                .HasForeignKey(d => d.SodorCreationUserId)
                .HasConstraintName("FK_PaymentCommand_User1");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.ToTable("PaymentDetail", "treasury", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به جزییات پرداخت استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول ChequeTurnover");
            entity.Property(e => e.Amount)
                .HasComment("مبلغ مربوط به جزییات پرداخت")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد رسید جزییات پرداخت")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.PaymentDetailDate)
                .HasComment("تاریخ مربوط به جزییات پرداخت")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentDetailNumber)
                .HasMaxLength(10)
                .HasComment("سریال مربوط به جزییات پرداخت");
            entity.Property(e => e.PaymentId)
                .HasComment("شناسه خارجی جدول Payment")
                .HasColumnName("Payment_Id");
            entity.Property(e => e.PersonId)
                .HasComment("شناسه خارجی جدول Person")
                .HasColumnName("Person_Id");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentDetail_User");

            entity.HasOne(d => d.Payment).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentDetail_Payment");

            entity.HasOne(d => d.Person).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentDetail_Person");
        });

        modelBuilder.Entity<PaymentRequest>(entity =>
        {
            entity.ToTable("PaymentRequest", "treasury", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به ددرخواست های پرداخت استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول PaymentRequest");
            entity.Property(e => e.Amount)
                .HasComment("مبلغ پرداخت شده")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.CashDeskId)
                .HasComment("شناسه خارجی جدول CashDesk")
                .HasColumnName("CashDesk_Id");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد درخواست پرداخت")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.FactorId).HasComment("شناسه فاکتور خرید یا برگشت فروش بدون ایجاد رابطه");
            entity.Property(e => e.FactorType).HasComment("نوع فاکتور");
            entity.Property(e => e.FinancialPeriodId)
                .HasComment("شناسه خارجی جدول FinancialPeriod")
                .HasColumnName("FinancialPeriod_Id");
            entity.Property(e => e.PaymentRequestDate)
                .HasComment("تاریخ مربوط به درخواست پرداخت")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentRequestNumber)
                .HasMaxLength(10)
                .HasComment("سریال مربوط به درخواست پرداخت");
            entity.Property(e => e.PaymentRequestType).HasComment("نوع درخواست پرداخت");
            entity.Property(e => e.PersonId)
                .HasComment("شناسه خارجی جدول Person")
                .HasColumnName("Person_Id");

            entity.HasOne(d => d.Branch).WithMany(p => p.PaymentRequests)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentRequest_Branch");

            entity.HasOne(d => d.CashDesk).WithMany(p => p.PaymentRequests)
                .HasForeignKey(d => d.CashDeskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentRequest_CashDesk");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.PaymentRequests)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentRequest_User");

            entity.HasOne(d => d.FinancialPeriod).WithMany(p => p.PaymentRequests)
                .HasForeignKey(d => d.FinancialPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentRequest_FinancialPeriod");

            entity.HasOne(d => d.Person).WithMany(p => p.PaymentRequests)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentRequest_Person");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Permissions");

            entity.ToTable("Permission", "user", tb => tb.HasComment("تعیین سطح دسترسی ها برای هر فرم"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Permission");
            entity.Property(e => e.ModuleId)
                .HasComment("فرم یا بخشی که قرار است سطح دسترسی به آن اعمال شود")
                .HasColumnName("Module_Id");
            entity.Property(e => e.PermissionType)
                .HasMaxLength(100)
                .HasComment("نوع سطح دسترسی مشخص می شود");

            entity.HasOne(d => d.Module).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permissions_Module");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person", "basic", tb => tb.HasComment("جهت نگهداری اطلاعات اشخاص برای هر کسب و کار استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Person");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasComment("آدرس شخص");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.CityId)
                .HasComment("شناسه خارجی جدول City")
                .HasColumnName("City_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .HasComment("کد شناسایی شخص");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(40)
                .HasComment("نام شرکت");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد شخص")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.EconomicalNumber)
                .HasMaxLength(12)
                .HasComment("شماره اقتصادی شخص");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasComment("ایمیل شخص");
            entity.Property(e => e.Fax)
                .HasMaxLength(8)
                .HasComment("فکس شخص");
            entity.Property(e => e.Fname)
                .HasMaxLength(20)
                .HasComment("نام شخص")
                .HasColumnName("FName");
            entity.Property(e => e.GroupPersonId)
                .HasComment("شناسه خارجی جدول GroupPerson")
                .HasColumnName("GroupPerson_Id");
            entity.Property(e => e.IsAgent).HasComment("شخص آیا نماینده است");
            entity.Property(e => e.IsCustomer).HasComment("شخص آیا مشتری است");
            entity.Property(e => e.IsEmployee).HasComment("شخص آیا کارمند است");
            entity.Property(e => e.IsReceiver).HasComment("شخص آیا گیرنده است");
            entity.Property(e => e.IsSeller).HasComment("شخص آیا فروشنده است");
            entity.Property(e => e.IsSlanderer).HasComment("شخص آیا تنخواه گردان است");
            entity.Property(e => e.IsVisitor).HasComment("شخص آیا بازاریاب است");
            entity.Property(e => e.Lname)
                .HasMaxLength(30)
                .HasComment("نام خانوادگی شخص")
                .HasColumnName("LName");
            entity.Property(e => e.Mobile)
                .HasMaxLength(11)
                .HasComment("موبایل شخص");
            entity.Property(e => e.NationalCode)
                .HasMaxLength(10)
                .HasComment("کدملی شخص");
            entity.Property(e => e.NationalId)
                .HasMaxLength(11)
                .HasComment("شناسه ملی شخص");
            entity.Property(e => e.PersonType).HasComment("نوع شخص (T : حقیقی - F: حقوقی)");
            entity.Property(e => e.PictureId)
                .HasComment("شناسه جدول خارجی تصویر شخص")
                .HasColumnName("Picture_Id");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasComment("کدپستی شخص");
            entity.Property(e => e.ProvinceId)
                .HasComment("شناسه خارجی جدول Province")
                .HasColumnName("Province_Id");
            entity.Property(e => e.RegistrationNumber)
                .HasMaxLength(12)
                .HasComment("شماره ثبت شرکت ");
            entity.Property(e => e.State)
                .HasDefaultValueSql("((1))")
                .HasComment("وضعیت فعالیت مشتری");
            entity.Property(e => e.Tel)
                .HasMaxLength(8)
                .HasComment("تلفن شخص");
            entity.Property(e => e.TitleId)
                .HasComment("شناسه خارجی جدول Title")
                .HasColumnName("Title_Id");
            entity.Property(e => e.VisitorPercentage)
                .HasDefaultValueSql("((0))")
                .HasComment("درصد حق الزحمه بازاریاب")
                .HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Branch).WithMany(p => p.People)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Person_Branch");

            entity.HasOne(d => d.City).WithMany(p => p.People)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Person_City");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.People)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Person_User");

            entity.HasOne(d => d.GroupPerson).WithMany(p => p.People)
                .HasForeignKey(d => d.GroupPersonId)
                .HasConstraintName("FK_Person_GroupPerson");

            entity.HasOne(d => d.Picture).WithMany(p => p.People)
                .HasForeignKey(d => d.PictureId)
                .HasConstraintName("FK_Person_Media");

            entity.HasOne(d => d.Province).WithMany(p => p.People)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("FK_Person_Province");

            entity.HasOne(d => d.Title).WithMany(p => p.People)
                .HasForeignKey(d => d.TitleId)
                .HasConstraintName("FK_Person_Title");
        });

        modelBuilder.Entity<PersonAgent>(entity =>
        {
            entity.ToTable("PersonAgent", "basic", tb => tb.HasComment("جهت نگهداری اطلاعات و ارتباط بین نماینده و مشتری استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول PersonAgent");
            entity.Property(e => e.AgentId)
                .HasComment("شناسه خارجی جدول Person")
                .HasColumnName("Agent_Id");
            entity.Property(e => e.PersonId)
                .HasComment("شناسه خارجی جدول Person")
                .HasColumnName("Person_Id");

            entity.HasOne(d => d.Agent).WithMany(p => p.PersonAgentAgents)
                .HasForeignKey(d => d.AgentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonAgent_Person1");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonAgentPeople)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonAgent_Person");
        });

        modelBuilder.Entity<PersonBeginningBalance>(entity =>
        {
            entity.ToTable("PersonBeginningBalance", "treasury", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به مانده ریالی اشخاص استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول PersonBeginningBalance");
            entity.Property(e => e.Amount)
                .HasDefaultValueSql("((0))")
                .HasComment("مبلغ مانده ابتدای دوره")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.FinancialPeriodId)
                .HasComment("شناسه خارجی جدول FinancialPeriod")
                .HasColumnName("FinancialPeriod_Id");
            entity.Property(e => e.PersonId)
                .HasComment("شناسه خارجی جدول Person")
                .HasColumnName("Person_Id");
            entity.Property(e => e.Status).HasComment("وضعیت بدهکار یا بستانکار بودن مانده");

            entity.HasOne(d => d.Branch).WithMany(p => p.PersonBeginningBalances)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_PersonBeginningBalance_Branch");

            entity.HasOne(d => d.FinancialPeriod).WithMany(p => p.PersonBeginningBalances)
                .HasForeignKey(d => d.FinancialPeriodId)
                .HasConstraintName("FK_PersonBeginningBalance_FinancialPeriod");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonBeginningBalances)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_PersonBeginningBalance_Person");
        });

        modelBuilder.Entity<Plan>(entity =>
        {
            entity.ToTable("Plan", "manage", tb => tb.HasComment("جهت نگهداری پلن ها و طرح های فروش مربوط به نرم افزار نگهداری می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Plan");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد کاربر")
                .HasColumnType("datetime");
            entity.Property(e => e.DiscountedPrice)
                .HasDefaultValueSql("((0))")
                .HasComment("مبلغ پس از تخفیف در طرح فروش")
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.IsActive).HasComment("وضعیت فعال بودن طرح");
            entity.Property(e => e.Period).HasComment("دوره زمانی هر طرح که چقدر طول می کشد  بر اساس تعداد ماه");
            entity.Property(e => e.Price)
                .HasComment("مبلغ طرح فروش")
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Property)
                .HasMaxLength(500)
                .HasComment("مشخصات و قابلیت های هر طرح با فرمت جیسون");
            entity.Property(e => e.Title)
                .HasMaxLength(25)
                .HasComment("عنوان طرح فروش");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product", "basic", tb => tb.HasComment("جهت نگهداری اطلاعات کالا استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Product");
            entity.Property(e => e.AgentPricePercent)
                .HasDefaultValueSql("((0))")
                .HasComment("درصد مبلغ فروش به نماینده کالا بر اساس آخرین قیمت خرید")
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.BarCode)
                .HasMaxLength(20)
                .HasComment("بارکد کالا");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.BuyMaxOrder)
                .HasDefaultValueSql("((0))")
                .HasComment("مقدار مجاز خرید جهت سفارش کالا")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasComment("کد کالا");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات کالا");
            entity.Property(e => e.DiscountPercent)
                .HasDefaultValueSql("((0))")
                .HasComment("درصد تخفیف کالا")
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.FactorTitle)
                .HasMaxLength(60)
                .HasComment("عنوان دوم کالا");
            entity.Property(e => e.InitialBalance)
                .HasDefaultValueSql("((0))")
                .HasComment("مقدار موجودی اولیه کالا")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.InitialPrice)
                .HasDefaultValueSql("((0))")
                .HasComment("مبلغ موجودی اولیه کالا")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.IsBuyTaxable)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("مجاز به دریافت ارزش افزوده در خرید؟");
            entity.Property(e => e.IsProduct)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("آیا کالا است یا خدمات؟");
            entity.Property(e => e.IsSalable)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("آیا قابل فروش است؟");
            entity.Property(e => e.IsSaleTaxable)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("مجاز به دریافت ارزش افزوده در فروش؟");
            entity.Property(e => e.IsUseStore).HasComment("آیا قابل استفاده در سایت می باشد؟");
            entity.Property(e => e.MainUnit).HasComment("شناسه خارجی جدول Unit - واحد اصلی");
            entity.Property(e => e.MediaId)
                .HasComment("شناسه خارجی جدول Media")
                .HasColumnName("Media_Id");
            entity.Property(e => e.OrderPoint)
                .HasDefaultValueSql("((0))")
                .HasComment("نقطه سفارش کالا")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.PricingMethod)
                .HasDefaultValueSql("((1))")
                .HasComment("روش قیمت گذاری فروش کالا");
            entity.Property(e => e.ProductGroupId)
                .HasComment("شناسه خارجی جدول ProductGroup - گروه بندی کالا")
                .HasColumnName("ProductGroup_Id");
            entity.Property(e => e.SalePricePercent)
                .HasDefaultValueSql("((0))")
                .HasComment("درصد مبلغ فروش کالا بر اساس آخرین قیمت خرید")
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.SecondUnit).HasComment("شناسه خارجی جدول Unit - واحد فرعی و دوم");
            entity.Property(e => e.SecondUnitCount)
                .HasDefaultValueSql("((0))")
                .HasComment("رابطه مقداری واحد فرعی و اصلی")
                .HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Title)
                .HasMaxLength(60)
                .HasComment("عنوان کالا");
            entity.Property(e => e.WarehousePricingMethod)
                .HasDefaultValueSql("((2))")
                .HasComment("روش قیمت گذاری قیمت تمام شده انبار");
            entity.Property(e => e.WholePricePercent)
                .HasDefaultValueSql("((0))")
                .HasComment("درصد مبلغ فروش عمده کالا بر اساس آخرین قیمت خرید")
                .HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Branch).WithMany(p => p.Products)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Branch");

            entity.HasOne(d => d.Media).WithMany(p => p.Products)
                .HasForeignKey(d => d.MediaId)
                .HasConstraintName("FK_Product_Media");

            entity.HasOne(d => d.ProductGroup).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductGroupId)
                .HasConstraintName("FK_Product_ProductGroup");
        });

        modelBuilder.Entity<ProductGroup>(entity =>
        {
            entity.ToTable("ProductGroup", "basic", tb => tb.HasComment("جهت نگهداری اطلاعات گروه بندی و دسته بندی های کالا استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول ProductGroup");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .HasComment("کد گروه بندی کالا");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.EndFlag).HasComment("آیا آخرین لایه است یا خیر . یعنی بعد از این لایه ، کالا قرار می گیرند ");
            entity.Property(e => e.LevelNumber).HasComment("شماره لایه و سطح را مشخص میکند");
            entity.Property(e => e.ParentId).HasComment("شناسه پدر هر سطح ازکالا");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .HasComment("عنوان گروه بندی کالا");

            entity.HasOne(d => d.Branch).WithMany(p => p.ProductGroups)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductGroup_Branch");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.ToTable("Province", "pub", tb => tb.HasComment("جهت نگهداری اطلاعات استان ها استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Province");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .HasComment("عنوان استان");
        });

        modelBuilder.Entity<PublicEnum>(entity =>
        {
            entity.ToTable("PublicEnum", "pub", tb => tb.HasComment("جهت نگهداری اطلاعات پایه ای در سیستم استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول PublicEnum");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .HasComment("کد عنوان عمومی");
            entity.Property(e => e.Title)
                .HasMaxLength(40)
                .HasComment("عنوان اطلاعات عمومی");
            entity.Property(e => e.Type).HasComment("نوع و دسته بندی اطلاعات پایه");
        });

        modelBuilder.Entity<Reason>(entity =>
        {
            entity.ToTable("Reason", "basic", tb => tb.HasComment("جهت نگهداری دلایل غیرفعال کردن استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Reason");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .HasComment("کد دلیل");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasComment("عنوان دلیل");

            entity.HasOne(d => d.Branch).WithMany(p => p.Reasons)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reason_Branch");
        });

        modelBuilder.Entity<Receive>(entity =>
        {
            entity.ToTable("Receive", "treasury", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط دریافت کلیه وجوه و اسناد استفاده می شود . عموما بوسیله فروش کالا و یا برگشت خرید پر می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Receive");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.CashDeskId)
                .HasComment("شناسه خارجی جدول CashDesk")
                .HasColumnName("CashDesk_Id");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد رسید دریافت")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.FinancialPeriodId)
                .HasComment("شناسه خارجی جدول FinancialPeriod")
                .HasColumnName("FinancialPeriod_Id");
            entity.Property(e => e.PersonId)
                .HasComment("شناسه خارجی جدول Person")
                .HasColumnName("Person_Id");
            entity.Property(e => e.ReceiveDate)
                .HasComment("تاریخ دریافت")
                .HasColumnType("datetime");
            entity.Property(e => e.ReceiveNumber)
                .HasMaxLength(10)
                .HasComment("شماره رسید دریافت");
            entity.Property(e => e.ReceiveType).HasComment("نوع دریافت وجه را مشخص می کند");

            entity.HasOne(d => d.Branch).WithMany(p => p.Receives)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receive_Branch");

            entity.HasOne(d => d.CashDesk).WithMany(p => p.Receives)
                .HasForeignKey(d => d.CashDeskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receive_CashDesk");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.Receives)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receive_User");

            entity.HasOne(d => d.FinancialPeriod).WithMany(p => p.Receives)
                .HasForeignKey(d => d.FinancialPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receive_FinancialPeriod");

            entity.HasOne(d => d.Person).WithMany(p => p.Receives)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receive_Person");
        });

        modelBuilder.Entity<ReceiveDetail>(entity =>
        {
            entity.ToTable("ReceiveDetail", "treasury", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به جزییات دریافت کلیه وجوه و اسناد استفاده می شود . عموما بوسیله فروش کالا و یا برگشت خرید پر می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Receive");
            entity.Property(e => e.Amount)
                .HasComment("مبلغ دریافت شده")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.BankBranch)
                .HasMaxLength(40)
                .HasComment("شعبه بانک");
            entity.Property(e => e.BankId)
                .HasComment("شناسه خارجی جدول Bank")
                .HasColumnName("Bank_Id");
            entity.Property(e => e.ChequeAccountNumber)
                .HasMaxLength(24)
                .HasComment("شماره حساب سند / چک");
            entity.Property(e => e.ChequeBankId).HasComment("شناسه جدول PublicEnum با گروه 01");
            entity.Property(e => e.ChequeDate)
                .HasComment("تاریخ سند / چک")
                .HasColumnType("datetime");
            entity.Property(e => e.ChequeDescription)
                .HasMaxLength(100)
                .HasComment("توضیحات سند  / بابت چک");
            entity.Property(e => e.ChequeSerial)
                .HasMaxLength(20)
                .HasComment("سریال سند / چک");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد رسید دریافت")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.FactorId).HasComment("شناسه فاکتور فروش یا برگشت خرید بدون ایجاد رابطه");
            entity.Property(e => e.FactorType).HasComment("نوع فاکتور");
            entity.Property(e => e.IsGarantyCheque)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("چک ضمانت است یا جاری؟");
            entity.Property(e => e.IsInClosedCash).HasComment("آیا صندوق بسته شده یا خیر؟");
            entity.Property(e => e.ReceiveId)
                .HasComment("شناسه خارجی جدول Receive")
                .HasColumnName("Receive_Id");

            entity.HasOne(d => d.Bank).WithMany(p => p.ReceiveDetails)
                .HasForeignKey(d => d.BankId)
                .HasConstraintName("FK_ReceiveDetail_Bank");

            entity.HasOne(d => d.ChequeBank).WithMany(p => p.ReceiveDetails)
                .HasForeignKey(d => d.ChequeBankId)
                .HasConstraintName("FK_ReceiveDetail_PublicEnum");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.ReceiveDetails)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceiveDetail_User");

            entity.HasOne(d => d.Receive).WithMany(p => p.ReceiveDetails)
                .HasForeignKey(d => d.ReceiveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceiveDetail_Receive");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.ToTable("RefreshToken", "user");

            entity.Property(e => e.AddedDate)
                .HasComment("تاریخ ثبت")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpiryDate)
                .HasComment("تاریخ انقضا")
                .HasColumnType("datetime");
            entity.Property(e => e.IsRevoked).HasComment("آیا رفرش توکن کنسل شده است؟");
            entity.Property(e => e.IsUsed).HasComment("آیا از رفرش توکن قبلا جهت دریافت نسخه جدید استفاده شده؟");
            entity.Property(e => e.JwtId)
                .HasMaxLength(100)
                .HasComment("شناسه توکن اصلی");
            entity.Property(e => e.Token)
                .HasMaxLength(100)
                .HasComment("توکن");
            entity.Property(e => e.UserId)
                .HasComment("شناسه کاربر درخواست کننده توکن و رفرش توکن")
                .HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_RefreshToken_RefreshToken");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Roles", "user", tb => tb.HasComment("به منظور نگهداری نقش های سیستم استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Roles");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasComment("عنوان نقش");
        });

        modelBuilder.Entity<SaleInvoice>(entity =>
        {
            entity.ToTable("SaleInvoice", "warehouse", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به فروش کالا استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول SaleInvoice");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد فاکتور")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Customer).HasComment("شناسه خارجی جدول Person - مشتری");
            entity.Property(e => e.CustomerTitle)
                .HasMaxLength(70)
                .HasComment("عنوان مشتری در فاکتور فروش");
            entity.Property(e => e.DeliveryDate)
                .HasComment("تاریخ تحویل فاکتور به مشتری")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.DueDate)
                .HasComment("تاریخ سررسید")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpiredDate)
                .HasComment("تاریخ انقضای پیش فاکتور")
                .HasColumnType("datetime");
            entity.Property(e => e.FinancialPeriodId)
                .HasComment("شناسه خارجی جدول FinancialPeriod")
                .HasColumnName("FinancialPeriod_Id");
            entity.Property(e => e.InvoiceDate)
                .HasComment("تاریخ فاکتور")
                .HasColumnType("datetime");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(10)
                .HasComment("شماره فاکتور");
            entity.Property(e => e.InvoiceType).HasComment("نوع فاکتور");
            entity.Property(e => e.RelatedInvoiceNumber)
                .HasMaxLength(10)
                .HasComment("شماره فاکتور برگشت فروش");
            entity.Property(e => e.StoreInvoiceNumber)
                .HasMaxLength(10)
                .HasComment("شماره فاکتور در فروشگاه و سایت اینترنتی");
            entity.Property(e => e.TotalDiscountAmount)
                .HasDefaultValueSql("((0))")
                .HasComment("مبلغ تخفیف که روی کل فاکتور ثبت می شود")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.TotalDiscountPercent)
                .HasDefaultValueSql("((0))")
                .HasComment("درصد تخفیف که روی کل فاکتور ثبت می شود")
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TransportCost)
                .HasDefaultValueSql("((0))")
                .HasComment("هزینه حمل کالا")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Visitor).HasComment("شناسه خارجی جدول Person - بازاریاب");
            entity.Property(e => e.VisitorPercent)
                .HasDefaultValueSql("((0))")
                .HasComment("درصد محاسبه شده بابت این فاکتور برای ویزیتور")
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.WarehouseId)
                .HasComment("شناسه خارجی جدول Warehouse")
                .HasColumnName("Warehouse_Id");

            entity.HasOne(d => d.Branch).WithMany(p => p.SaleInvoices)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleInvoice_Branch");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.SaleInvoices)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleInvoice_User");

            entity.HasOne(d => d.CustomerNavigation).WithMany(p => p.SaleInvoiceCustomerNavigations)
                .HasForeignKey(d => d.Customer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleInvoice_Person");

            entity.HasOne(d => d.FinancialPeriod).WithMany(p => p.SaleInvoices)
                .HasForeignKey(d => d.FinancialPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleInvoice_FinancialPeriod");

            entity.HasOne(d => d.VisitorNavigation).WithMany(p => p.SaleInvoiceVisitorNavigations)
                .HasForeignKey(d => d.Visitor)
                .HasConstraintName("FK_SaleInvoice_Person1");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.SaleInvoices)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK_SaleInvoice_Warehouse");
        });

        modelBuilder.Entity<SaleInvoiceDetail>(entity =>
        {
            entity.ToTable("SaleInvoiceDetail", "warehouse", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به جزییات فروش کالا استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول SaleInvoiceDetail");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد جزییات فاکتور")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.Discount)
                .HasDefaultValueSql("((0))")
                .HasComment("تخفیف مربوط به هر کالا")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.DiscountPercent)
                .HasDefaultValueSql("((0))")
                .HasComment("درصد تخفیف مربوط به هر کالا")
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.FixedPrice)
                .HasDefaultValueSql("((0))")
                .HasComment("قیمت تمام شده کالا")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.MainAmount)
                .HasComment("مقدار اصلی")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Price)
                .HasComment("مبلغ واحد")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ProductId)
                .HasComment("شناسه خارجی جدول Product")
                .HasColumnName("Product_Id");
            entity.Property(e => e.RowNumber).HasComment("شماره ردیف جزییات هر سند");
            entity.Property(e => e.SaleInvoiceId)
                .HasComment("شناسه خارجی جدول SaleInvoice")
                .HasColumnName("SaleInvoice_Id");
            entity.Property(e => e.SecondAmount)
                .HasDefaultValueSql("((0))")
                .HasComment("مقدار فرعی")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Vat1)
                .HasDefaultValueSql("((0))")
                .HasComment("مبلغ مالیات بر ارزش افزوده")
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Vat2)
                .HasDefaultValueSql("((0))")
                .HasComment("مبلغ عوارض ارزش افزوده")
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.WarehouseId)
                .HasComment("شناسه خارجی جدول Warehouse")
                .HasColumnName("Warehouse_Id");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.SaleInvoiceDetails)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleInvoiceDetail_User");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleInvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleInvoiceDetail_Product");

            entity.HasOne(d => d.SaleInvoice).WithMany(p => p.SaleInvoiceDetails)
                .HasForeignKey(d => d.SaleInvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleInvoiceDetail_SaleInvoice");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.SaleInvoiceDetails)
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK_SaleInvoiceDetail_Warehouse");
        });

        modelBuilder.Entity<Template>(entity =>
        {
            entity.ToTable("Template", "basic", tb => tb.HasComment("جهت نگهداری اطلاعات و شرح  های پیش فرض برای ردیف و یا سند در سندهای حسابداری استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Template");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .HasComment("کد شرح پیش فرض");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasComment("عنوان شرح پیش فرض");

            entity.HasOne(d => d.Branch).WithMany(p => p.Templates)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Template_Branch");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("Ticket", "manage", tb => tb.HasComment("جهت نگهداری تیکت های پشتیبانی کاربران و کسب و کارها استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Ticket");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.CreationDate)
                .HasComment("تاریخ ایجاد سطر در تیکت")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("شرح تیکت");
            entity.Property(e => e.IsAdmin).HasComment("آیا این سطر مربوط به کاربر است یا ادمین (T : User - F : Admin)");
            entity.Property(e => e.IsClose).HasComment("آیا تیکت بسته شده است - فقط در رکورد آخر ثبت می شود و الباقی F باشند .");
            entity.Property(e => e.MediaId)
                .HasComment("شناسه خارجی جدول Media جهت ذخیره سازی تصویر")
                .HasColumnName("Media_Id");
            entity.Property(e => e.ReadDate)
                .HasComment("تاریخ مشاهده و خواندن تیکت")
                .HasColumnType("datetime");
            entity.Property(e => e.ReferTo).HasComment("مربوط به کدام دپارتمان است");
            entity.Property(e => e.Serial)
                .HasMaxLength(30)
                .HasComment("سریال تیکت");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasComment("عنوان تیکت");
            entity.Property(e => e.UserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("User_Id");

            entity.HasOne(d => d.Branch).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Ticket_Branch");

            entity.HasOne(d => d.Media).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.MediaId)
                .HasConstraintName("FK_Ticket_Media");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Ticket_User");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.ToTable("Title", "pub", tb => tb.HasComment("جهت نگهداری اطلاعات عناوین اشخاص استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Title");
            entity.Property(e => e.Title1)
                .HasMaxLength(20)
                .HasComment("عنوان شخص")
                .HasColumnName("Title");
            entity.Property(e => e.TitleType)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("نوع عنوان ( T : حقیقی F : حقوقی)");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.ToTable("Unit", "pub", tb => tb.HasComment("جهت نگهداری اطلاعات واحدهای اندازه گیری استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Unit");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .HasComment("کد واحد اندازه گیری");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .HasComment("عنوان واحد اندازه گیری");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User", "user", tb => tb.HasComment("جهت نگهداری اطلاعات کاربران نرم افزار و هر فروشگاه استفاده می شود . ممکن است برخی کاربران در چند فروشگاه امکان ورود داشته باشند"));

            entity.Property(e => e.Id).HasComment("شناسه جدول User");
            entity.Property(e => e.CreationDate)
                .HasComment("تاریخ ایجاد کاربر")
                .HasColumnType("datetime");
            entity.Property(e => e.Username)
              .HasMaxLength(30)
              .HasComment("نام کاربری");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasComment(" ایمیل کاربر");
            entity.Property(e => e.Fname)
                .HasMaxLength(20)
                .HasComment("نام کاربر")
                .HasColumnName("FName");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("وضعیت فعال بودن کاربر");
            entity.Property(e => e.LastLoginDate)
                .HasDefaultValueSql("(((1900)-(1))-(1))")
                .HasComment("آخرین ورود کاربر - اگر هنوز لاگین نکرده ، تاریخ 1900-01-01 درج شود")
                .HasColumnType("datetime");
            entity.Property(e => e.Lname)
                .HasMaxLength(30)
                .HasComment("نام خانوادگی کاربر")
                .HasColumnName("LName");
            entity.Property(e => e.Mobile)
                .HasMaxLength(11)
                .HasComment("موبایل");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasComment("کلمه عبور ");
            entity.Property(e => e.RoleId)
                .HasComment("شناسه خارجی جدول Roles")
                .HasColumnName("Role_Id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Roles");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.ToTable("Voucher", "acc", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به اسناد حسابداری استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Voucher");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.Cartable).HasComment("نوع کارتابل");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد سند حسابداری")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات سند حسابداری");
            entity.Property(e => e.FinancialPeriodId)
                .HasComment("شناسه خارجی جدول FinancialPeriod")
                .HasColumnName("FinancialPeriod_Id");
            entity.Property(e => e.IsAutomatic).HasComment("آیا سند اتوماتیک است یا خیر");
            entity.Property(e => e.VoucherDate)
                .HasComment("تاریخ تایید سند ")
                .HasColumnType("datetime");
            entity.Property(e => e.VoucherDateTemp)
                .HasComment("تاریخ سند موقت")
                .HasColumnType("datetime");
            entity.Property(e => e.VoucherNumber)
                .HasMaxLength(10)
                .HasComment("شماره سند تایید شده");
            entity.Property(e => e.VoucherNumberTemp)
                .HasMaxLength(10)
                .HasComment("شماره سند موقت");
            entity.Property(e => e.VoucherType).HasComment("نوع سند");

            entity.HasOne(d => d.Branch).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Voucher_Branch");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Voucher_User");

            entity.HasOne(d => d.FinancialPeriod).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.FinancialPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Voucher_FinancialPeriod");
        });

        modelBuilder.Entity<VoucherDetail>(entity =>
        {
            entity.ToTable("VoucherDetail", "acc", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به جزییات اسناد حسابداری استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول VoucherDetail");
            entity.Property(e => e.Account).HasComment("شناسه خارجی جدول AccountTitle مربوط به کد حساب");
            entity.Property(e => e.AttachmentId).HasComment("شناسه رسید متصل شده به ردیف");
            entity.Property(e => e.AttachmentType).HasComment("نوع رسید متصل شده به ردیف");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد ردیف سند حسابداری")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Cridetor)
                .HasComment("مبلغ بستانکار")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Debtor)
                .HasComment("مبلغ بدهکار")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات ردیف سند حسابداری");
            entity.Property(e => e.PersonId)
                .HasComment("شناسه خارجی جدول Person مربوط به کد حساب طرف حساب")
                .HasColumnName("Person_Id");
            entity.Property(e => e.RowNumber).HasComment("شماره ردیف جزییات هر سند");
            entity.Property(e => e.VoucherId)
                .HasComment("شناسه خارجی جدول Voucher")
                .HasColumnName("Voucher_Id");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.VoucherDetails)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VoucherDetail_User");

            entity.HasOne(d => d.Person).WithMany(p => p.VoucherDetails)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_VoucherDetail_Person");

            entity.HasOne(d => d.Voucher).WithMany(p => p.VoucherDetails)
                .HasForeignKey(d => d.VoucherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VoucherDetail_Voucher");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.ToTable("Warehouse", "basic", tb => tb.HasComment("جهت نگهداری اطلاعات انبار یا فروشگاه استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول Warehouse");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .HasComment("کد انبار یا فروشگاه");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasComment("عنوان انبار یا فروشگاه");

            entity.HasOne(d => d.Branch).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_Branch");
        });

        modelBuilder.Entity<WarehouseMoveing>(entity =>
        {
            entity.ToTable("WarehouseMoveing", "warehouse", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به جابه جایی کالا بین انبارها استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول BeginningBalance");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد فاکتور")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.FinancialPeriodId)
                .HasComment("شناسه خارجی جدول FinancialPeriod")
                .HasColumnName("FinancialPeriod_Id");
            entity.Property(e => e.InvoiceDate)
                .HasComment("تاریخ فاکتور")
                .HasColumnType("datetime");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(10)
                .HasComment("شماره فاکتور");
            entity.Property(e => e.WarehouseInId)
                .HasComment("شناسه خارجی جدول Warehouse - انبار مبدا")
                .HasColumnName("WarehouseIn_Id");
            entity.Property(e => e.WarehouseOutId)
                .HasComment("شناسه خارجی جدول Warehouse - انبار مقصد")
                .HasColumnName("WarehouseOut_Id");

            entity.HasOne(d => d.Branch).WithMany(p => p.WarehouseMoveings)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WarehouseMoveing_Branch");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.WarehouseMoveings)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WarehouseMoveing_User");

            entity.HasOne(d => d.FinancialPeriod).WithMany(p => p.WarehouseMoveings)
                .HasForeignKey(d => d.FinancialPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WarehouseMoveing_FinancialPeriod");

            entity.HasOne(d => d.WarehouseIn).WithMany(p => p.WarehouseMoveingWarehouseIns)
                .HasForeignKey(d => d.WarehouseInId)
                .HasConstraintName("FK_WarehouseMoveing_Warehouse");

            entity.HasOne(d => d.WarehouseOut).WithMany(p => p.WarehouseMoveingWarehouseOuts)
                .HasForeignKey(d => d.WarehouseOutId)
                .HasConstraintName("FK_WarehouseMoveing_Warehouse1");
        });

        modelBuilder.Entity<WarehouseMoveingDetail>(entity =>
        {
            entity.ToTable("WarehouseMoveingDetail", "warehouse", tb => tb.HasComment("جهت نگهداری اطلاعات مربوط به جزییات جا به جایی کالا بین انبارها استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول WarehouseMoveingDetail");
            entity.Property(e => e.CreateDate)
                .HasComment("تاریخ ایجاد جزییات فاکتور")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasComment("شناسه خارجی جدول User")
                .HasColumnName("CreateUser_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("توضیحات");
            entity.Property(e => e.FixedPrice)
                .HasDefaultValueSql("((0))")
                .HasComment("قیمت تمام شده کالا")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.MainAmount)
                .HasComment("مقدار اصلی")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Price)
                .HasComment("مبلغ واحد")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ProductId)
                .HasComment("شناسه خارجی جدول Product")
                .HasColumnName("Product_Id");
            entity.Property(e => e.RowNumber).HasComment("شماره ردیف جزییات هر سند");
            entity.Property(e => e.SecondAmount)
                .HasDefaultValueSql("((0))")
                .HasComment("مقدار فرعی")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.WarehouseInId)
                .HasComment("شناسه خارجی جدول Warehouse انبار مبدا")
                .HasColumnName("WarehouseIn_Id");
            entity.Property(e => e.WarehouseMoveingId)
                .HasComment("شناسه خارجی جدول WarehouseMoveing")
                .HasColumnName("WarehouseMoveing_Id");
            entity.Property(e => e.WarehouseOutId).HasColumnName("WarehouseOut_Id");

            entity.HasOne(d => d.CreateUser).WithMany(p => p.WarehouseMoveingDetails)
                .HasForeignKey(d => d.CreateUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WarehouseMoveingDetail_User");

            entity.HasOne(d => d.Product).WithMany(p => p.WarehouseMoveingDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WarehouseMoveingDetail_Product");

            entity.HasOne(d => d.WarehouseIn).WithMany(p => p.WarehouseMoveingDetailWarehouseIns)
                .HasForeignKey(d => d.WarehouseInId)
                .HasConstraintName("FK_WarehouseMoveingDetail_Warehouse");

            entity.HasOne(d => d.WarehouseMoveing).WithMany(p => p.WarehouseMoveingDetails)
                .HasForeignKey(d => d.WarehouseMoveingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WarehouseMoveingDetail_WarehouseMoveing");

            entity.HasOne(d => d.WarehouseOut).WithMany(p => p.WarehouseMoveingDetailWarehouseOuts)
                .HasForeignKey(d => d.WarehouseOutId)
                .HasConstraintName("FK_WarehouseMoveingDetail_Warehouse1");
        });

        modelBuilder.Entity<WarehouseStock>(entity =>
        {
            entity.ToTable("WarehouseStock", "warehouse", tb => tb.HasComment("جهت نگهداری آخرین موجودی کالا استفاده می شود"));

            entity.Property(e => e.Id).HasComment("شناسه جدول WarehouseStock");
            entity.Property(e => e.AgentPrice)
                .HasDefaultValueSql("((0))")
                .HasComment("مبلغ فروش به نماینده (محاسبه بر اساس قیمت خرید و درصد ذکر شده معرفی کالا)")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Amount)
                .HasComment("مقدار موجودی کالا در انبار و سال مالی مربوطه برای هر کسب و کار")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.BranchId)
                .HasComment("شناسه خارجی جدول Branch")
                .HasColumnName("Branch_Id");
            entity.Property(e => e.BuyPrice)
                .HasDefaultValueSql("((0))")
                .HasComment("آخرین مبلغ خرید کالا")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.FinancialPeriodId)
                .HasComment("شناسه خارجی جدول FinancialPeriod")
                .HasColumnName("FinancialPeriod_Id");
            entity.Property(e => e.ProductId)
                .HasComment("شناسه خارجی جدول Product")
                .HasColumnName("Product_Id");
            entity.Property(e => e.RecordVersion)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasComment("مربوط به تکنیک Optimistic Concurrency");
            entity.Property(e => e.SalePrice)
                .HasDefaultValueSql("((0))")
                .HasComment("مبلغ فروش کالا (محاسبه بر اساس قیمت خرید و درصد ذکر شده معرفی کالا)")
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.WarehouseId)
                .HasComment("شناسه خارجی جدول Warehouse")
                .HasColumnName("Warehouse_Id");
            entity.Property(e => e.WholePrice)
                .HasDefaultValueSql("((0))")
                .HasComment("مبلغ فروش عمده (محاسبه بر اساس قیمت خرید و درصد ذکر شده معرفی کالا)")
                .HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.Branch).WithMany(p => p.WarehouseStocks)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WarehouseStock_Branch");

            entity.HasOne(d => d.FinancialPeriod).WithMany(p => p.WarehouseStocks)
                .HasForeignKey(d => d.FinancialPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WarehouseStock_FinancialPeriod");

            entity.HasOne(d => d.Product).WithMany(p => p.WarehouseStocks)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WarehouseStock_Product");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.WarehouseStocks)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WarehouseStock_Warehouse");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
