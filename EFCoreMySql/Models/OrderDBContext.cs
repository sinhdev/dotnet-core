using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCoreMySql.Models
{
    public partial class OrderDBContext : DbContext
    {
        public OrderDBContext()
        {
        }

        public OrderDBContext(DbContextOptions<OrderDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;user id=vtca;password=vtcacademy;port=3306;database=OrderDB;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers", "OrderDB");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(200)
                    .HasColumnName("customer_address");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("customer_name");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Items", "OrderDB");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(500)
                    .HasColumnName("item_description");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("item_name");

                entity.Property(e => e.ItemStatus).HasColumnName("item_status");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(20,2)")
                    .HasColumnName("unit_price")
                    .HasDefaultValueSql("'0.00'");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders", "OrderDB");

                entity.HasIndex(e => e.CustomerId, "fk_Orders_Customers");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.OrderStatus).HasColumnName("order_status");

                entity.Property(e => e.OrderDate).HasColumnName("order_date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_Orders_Customers");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ItemId })
                    .HasName("PRIMARY");

                entity.ToTable("OrderDetails", "OrderDB");

                entity.HasIndex(e => e.ItemId, "fk_OrderDetails_Items");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(20,2)")
                    .HasColumnName("unit_price");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OrderDetails_Items");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OrderDetails_Orders");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
