using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Sales_system.Models
{
    public partial class salesSystemContext : DbContext
    {
        public salesSystemContext()
        {
        }

        public salesSystemContext(DbContextOptions<salesSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<BusinessProduct> BusinessProducts { get; set; }
        public virtual DbSet<BusinessSupplier> BusinessSuppliers { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Concept> Concepts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SuppliersProduct> SuppliersProducts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Database=salesSystem;Username=postgres;Password=123456789");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>(entity =>
            {
                entity.ToTable("business");

                entity.HasIndex(e => e.FkUserId, "business_fk_user_id_index");

                entity.HasIndex(e => e.Id, "business_id_index");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .HasColumnName("address");

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("business_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()")
                    .HasAnnotation("Relational:ColumnType", "timestamp with time zone");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("deleted_at")
                    .HasAnnotation("Relational:ColumnType", "timestamp with time zone");

                entity.Property(e => e.FkUserId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fk_user_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()")
                    .HasAnnotation("Relational:ColumnType", "timestamp with time zone");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Businesses)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("business_users_id_fk");
            });

            modelBuilder.Entity<BusinessProduct>(entity =>
            {
                entity.HasKey(e => new { e.FkBusinessId, e.FkProductId })
                    .HasName("business_products_pk");

                entity.ToTable("business_products");

                entity.HasIndex(e => new { e.FkBusinessId, e.FkProductId }, "business_products_fk_business_id_fk_product_id_index");

                entity.Property(e => e.FkBusinessId).HasColumnName("fk_business_id");

                entity.Property(e => e.FkProductId).HasColumnName("fk_product_id");

                entity.HasOne(d => d.FkBusiness)
                    .WithMany(p => p.BusinessProducts)
                    .HasForeignKey(d => d.FkBusinessId)
                    .HasConstraintName("business_products_business_id_fk");

                entity.HasOne(d => d.FkProduct)
                    .WithMany(p => p.BusinessProducts)
                    .HasForeignKey(d => d.FkProductId)
                    .HasConstraintName("business_products_products_id_fk");
            });

            modelBuilder.Entity<BusinessSupplier>(entity =>
            {
                entity.HasKey(e => new { e.FkBusinessId, e.FkSupplierId })
                    .HasName("business_suppliers_pk_2");

                entity.ToTable("business_suppliers");

                entity.HasIndex(e => new { e.FkBusinessId, e.FkSupplierId }, "business_suppliers_fk_business_id_fk_supplier_id_index");

                entity.HasIndex(e => e.FkBusinessId, "business_suppliers_pk")
                    .IsUnique();

                entity.Property(e => e.FkBusinessId).HasColumnName("fk_business_id");

                entity.Property(e => e.FkSupplierId).HasColumnName("fk_supplier_id");

                entity.HasOne(d => d.FkBusiness)
                    .WithOne(p => p.BusinessSupplier)
                    .HasForeignKey<BusinessSupplier>(d => d.FkBusinessId)
                    .HasConstraintName("business_suppliers_business_id_fk");

                entity.HasOne(d => d.FkSupplier)
                    .WithMany(p => p.BusinessSuppliers)
                    .HasForeignKey(d => d.FkSupplierId)
                    .HasConstraintName("business_suppliers_suppliers_id_fk");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("client_name");
            });

            modelBuilder.Entity<Concept>(entity =>
            {
                entity.ToTable("concepts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasPrecision(16, 2)
                    .HasColumnName("amount")
                    .HasDefaultValueSql("0.0");

                entity.Property(e => e.FkProductId).HasColumnName("fk_product_id");

                entity.Property(e => e.FkSaleId).HasColumnName("fk_sale_id");

                entity.Property(e => e.PriceUnit)
                    .HasPrecision(16, 2)
                    .HasColumnName("price_unit");

                entity.Property(e => e.Total)
                    .HasPrecision(16, 2)
                    .HasColumnName("total");

                entity.HasOne(d => d.FkProduct)
                    .WithMany(p => p.Concepts)
                    .HasForeignKey(d => d.FkProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("concepts_products_id_fk");

                entity.HasOne(d => d.FkSale)
                    .WithMany(p => p.Concepts)
                    .HasForeignKey(d => d.FkSaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("concepts_sales_id_fk");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasPrecision(16)
                    .HasColumnName("amount");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("product_name");

                entity.Property(e => e.UnitPrice)
                    .HasPrecision(16, 2)
                    .HasColumnName("unit_price");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sales");

                entity.HasIndex(e => e.Id, "table_name_id_index");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()")
                    .HasAnnotation("Relational:ColumnType", "timestamp with time zone");

                entity.Property(e => e.FkClientId).HasColumnName("fk_client_id");

                entity.Property(e => e.Total)
                    .HasPrecision(16, 2)
                    .HasColumnName("total");

                entity.HasOne(d => d.FkClient)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.FkClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sales_clients_id_fk");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("suppliers");

                entity.HasIndex(e => e.FkUserId, "suppliers_fk_user_id_index");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()")
                    .HasAnnotation("Relational:ColumnType", "timestamp with time zone");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.FkUserId).HasColumnName("fk_user_id");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("phone");

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("supplier_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()")
                    .HasAnnotation("Relational:ColumnType", "timestamp with time zone");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("suppliers_users_id_fk");
            });

            modelBuilder.Entity<SuppliersProduct>(entity =>
            {
                entity.HasKey(e => new { e.FkSupplierId, e.FkProductId })
                    .HasName("suppliers_products_pk");

                entity.ToTable("suppliers_products");

                entity.HasIndex(e => new { e.FkSupplierId, e.FkProductId }, "suppliers_products_fk_supplier_id_fk_product_id_index");

                entity.Property(e => e.FkSupplierId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fk_supplier_id");

                entity.Property(e => e.FkProductId).HasColumnName("fk_product_id");

                entity.HasOne(d => d.FkProduct)
                    .WithMany(p => p.SuppliersProducts)
                    .HasForeignKey(d => d.FkProductId)
                    .HasConstraintName("suppliers_products_products_id_fk");

                entity.HasOne(d => d.FkSupplier)
                    .WithMany(p => p.SuppliersProducts)
                    .HasForeignKey(d => d.FkSupplierId)
                    .HasConstraintName("suppliers_products_suppliers_id_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Username, "users_username_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()")
                    .HasAnnotation("Relational:ColumnType", "timestamp with time zone");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("first_name");

                entity.Property(e => e.Surnames)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("surnames")
                    .HasAnnotation("Relational:ColumnType", "character varying");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()")
                    .HasAnnotation("Relational:ColumnType", "timestamp with time zone");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("user_password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(49)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
