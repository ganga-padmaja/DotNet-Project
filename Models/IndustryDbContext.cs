using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPIDBFirstApproach.Models;

public partial class IndustryDbContext : DbContext
{
    public IndustryDbContext()
    {
    }

    public IndustryDbContext(DbContextOptions<IndustryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Industry;User Id=sa;Password=Sqlserver@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Department");

            entity.Property(e => e.Dname)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DName");
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBA7977142A54");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("EmpID");
            entity.Property(e => e.City)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DepId).HasColumnName("DepID");
            entity.Property(e => e.Ename)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
