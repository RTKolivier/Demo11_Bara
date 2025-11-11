using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Barashikhina_Sofia.Models;

public partial class Db502Context : DbContext
{
    public Db502Context()
    {
    }

    public Db502Context(DbContextOptions<Db502Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Production> Productions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=lorksipt.ru; Port= 5432; Database= db502; Username= user502; Password=15789");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomersId).HasName("customers_pkey");

            entity.ToTable("customers", "demo11");

            entity.Property(e => e.CustomersId)
                .ValueGeneratedNever()
                .HasColumnName("customers_id");
            entity.Property(e => e.CustomersAddres).HasColumnName("customers_addres");
            entity.Property(e => e.CustomersBuyer).HasColumnName("customers_buyer");
            entity.Property(e => e.CustomersInn).HasColumnName("customers_inn");
            entity.Property(e => e.CustomersName).HasColumnName("customers_name");
            entity.Property(e => e.CustomersPhone).HasColumnName("customers_phone");
            entity.Property(e => e.CustomersSalesman).HasColumnName("customers_salesman");
        });

        modelBuilder.Entity<Production>(entity =>
        {
            entity.HasKey(e => e.ProductionId).HasName("production_pkey");

            entity.ToTable("production", "demo11");

            entity.Property(e => e.ProductionId)
                .ValueGeneratedNever()
                .HasColumnName("production_id");
            entity.Property(e => e.ProductionCost).HasColumnName("production_cost");
            entity.Property(e => e.ProductionName).HasColumnName("production_name");

            entity.HasMany(d => d.Customers).WithMany(p => p.Productions)
                .UsingEntity<Dictionary<string, object>>(
                    "Order",
                    r => r.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("orders_customers_id_fkey"),
                    l => l.HasOne<Production>().WithMany()
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("orders_production_id_fkey"),
                    j =>
                    {
                        j.HasKey("ProductionId", "CustomersId").HasName("orders_prod_cust_prkey");
                        j.ToTable("orders", "demo11");
                        j.IndexerProperty<int>("ProductionId").HasColumnName("production_id");
                        j.IndexerProperty<int>("CustomersId").HasColumnName("customers_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
