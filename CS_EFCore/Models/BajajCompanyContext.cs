using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CS_EFCore.Models
{
    public partial class BajajCompanyContext : DbContext
    {
        public BajajCompanyContext()
        {
        }

        public BajajCompanyContext(DbContextOptions<BajajCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BajajCompany;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptUniqueId)
                    .HasName("PK__Departme__A38858B3A01DF486");

                entity.ToTable("Department");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeptNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpUniqueId)
                    .HasName("PK__Employee__F8554A070E68DE5D");

                entity.ToTable("Employee");

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.DeptUnique) // One Department
                    .WithMany(p => p.Employees) // With Multiple Employees
                    .HasForeignKey(d => d.DeptUniqueId)
                    .HasConstraintName("FK__Employee__DeptUn__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
