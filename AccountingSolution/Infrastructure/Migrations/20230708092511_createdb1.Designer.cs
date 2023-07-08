﻿// <auto-generated />
using System;
using Infrastructure.Persistence.Entities.CrudTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CrudtestContext))]
    [Migration("20230708092511_createdb1")]
    partial class createdb1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Persistence.Entities.CrudTest.AccessControlList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("PermissionId")
                        .HasColumnType("bigint")
                        .HasColumnName("Permission_Id");

                    b.Property<long?>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("Role_Id");

                    b.HasKey("Id")
                        .HasName("PK__AccessCo__3214EC07B4FB2E31");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("AccessControlList", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.CrudTest.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("BankAccountNumber")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasDefaultValueSql("('')");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValueSql("('')");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<long?>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_Customer")
                        .IsUnique();

                    b.HasIndex(new[] { "Firstname", "Lastname", "DateOfBirth" }, "ucCodes")
                        .IsUnique()
                        .HasFilter("([DateOfBirth] IS NOT NULL)");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.CrudTest.Module", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ModuleName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Module__3214EC07A563BB96");

                    b.ToTable("Module", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.CrudTest.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("ModuleId")
                        .HasColumnType("bigint")
                        .HasColumnName("Module_Id");

                    b.Property<string>("PermissionType")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Permissi__3214EC076A04DB75");

                    b.HasIndex("ModuleId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.CrudTest.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("RoleName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Roles__3214EC079CDB040F");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.CrudTest.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("Role_Id");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.CrudTest.AccessControlList", b =>
                {
                    b.HasOne("Infrastructure.Persistence.Entities.CrudTest.Permission", "Permission")
                        .WithMany("AccessControlLists")
                        .HasForeignKey("PermissionId")
                        .HasConstraintName("FK__AccessCon__Permi__08B54D69");

                    b.HasOne("Infrastructure.Persistence.Entities.CrudTest.Role", "Role")
                        .WithMany("AccessControlLists")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__AccessCon__Role___07C12930");

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.CrudTest.Permission", b =>
                {
                    b.HasOne("Infrastructure.Persistence.Entities.CrudTest.Module", "Module")
                        .WithMany("Permissions")
                        .HasForeignKey("ModuleId")
                        .HasConstraintName("FK__Permissio__Modul__02FC7413");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.CrudTest.User", b =>
                {
                    b.HasOne("Infrastructure.Persistence.Entities.CrudTest.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_User_Roles");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.CrudTest.Module", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.CrudTest.Permission", b =>
                {
                    b.Navigation("AccessControlLists");
                });

            modelBuilder.Entity("Infrastructure.Persistence.Entities.CrudTest.Role", b =>
                {
                    b.Navigation("AccessControlLists");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
