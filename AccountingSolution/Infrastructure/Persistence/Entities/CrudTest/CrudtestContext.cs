using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Entities.CrudTest;

public partial class CrudtestContext : DbContext
{
    public CrudtestContext()
    {
    }

    public CrudtestContext(DbContextOptions<CrudtestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessControlList> AccessControlLists { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//    => optionsBuilder.UseSqlServer("Server=DESKTOP-LJH87UL;Database=CRUDTEST;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessControlList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccessCo__3214EC07B4FB2E31");

            entity.ToTable("AccessControlList");

            entity.Property(e => e.PermissionId).HasColumnName("Permission_Id");
            entity.Property(e => e.RoleId).HasColumnName("Role_Id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AccessControlLists)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__AccessCon__Permi__08B54D69");

            entity.HasOne(d => d.Role).WithMany(p => p.AccessControlLists)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__AccessCon__Role___07C12930");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.HasIndex(e => e.Email, "IX_Customer").IsUnique();

            entity.HasIndex(e => new { e.Firstname, e.Lastname, e.DateOfBirth }, "ucCodes")
                .IsUnique()
                .HasFilter("([DateOfBirth] IS NOT NULL)");

            entity.Property(e => e.BankAccountNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Firstname)
                .HasMaxLength(20)
                .HasDefaultValueSql("(N'')");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .HasDefaultValueSql("(N'')");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Module__3214EC07A563BB96");

            entity.ToTable("Module");

            entity.Property(e => e.ModuleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC076A04DB75");

            entity.Property(e => e.ModuleId).HasColumnName("Module_Id");
            entity.Property(e => e.PermissionType)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__Permissio__Modul__02FC7413");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC079CDB040F");

            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_User_Roles");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.ToTable("RefreshToken");

            entity.Property(e => e.AddedDate).HasColumnType("datetime");

            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

            entity.Property(e => e.JwtId)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.Property(e => e.Token)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
