using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Entities
{
    public partial class CRUDTESTContext : DbContext
    {
        public CRUDTESTContext()
        {
        }

        public CRUDTESTContext(DbContextOptions<CRUDTESTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
              //  optionsBuilder.UseSqlServer("Server=DESKTOP-LJH87UL;Database=CRUDTEST;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true ");
             //   optionsBuilder.UseSqlServer("Server=DESKTOP-LJH87UL;Database=CRUDTEST;User Id=sa;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.Email, "IX_Customer")
                    .IsUnique();

                entity.HasIndex(e => new { e.Firstname, e.Lastname, e.DateOfBirth }, "ucCodes")
                    .IsUnique();

                entity.Property(e => e.BankAccountNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname).HasMaxLength(20);

                entity.Property(e => e.Lastname).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
