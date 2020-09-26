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

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Concept> Concepts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
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

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Username, "users_username_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

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
