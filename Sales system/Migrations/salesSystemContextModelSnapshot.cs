﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sales_system.Models;

namespace Sales_system.Migrations
{
    [DbContext(typeof(salesSystemContext))]
    partial class salesSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0-rc.1.20451.13");

            modelBuilder.Entity("Sales_system.Models.Business", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("address");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)")
                        .HasColumnName("business_name");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<long>("FkUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("fk_user_id");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "FkUserId" }, "business_fk_user_id_index");

                    b.HasIndex(new[] { "Id" }, "business_id_index");

                    b.ToTable("business");
                });

            modelBuilder.Entity("Sales_system.Models.BusinessProduct", b =>
                {
                    b.Property<long>("FkBusinessId")
                        .HasColumnType("bigint")
                        .HasColumnName("fk_business_id");

                    b.Property<long>("FkProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("fk_product_id");

                    b.HasKey("FkBusinessId", "FkProductId")
                        .HasName("business_products_pk");

                    b.HasIndex("FkProductId");

                    b.HasIndex(new[] { "FkBusinessId", "FkProductId" }, "business_products_fk_business_id_fk_product_id_index");

                    b.ToTable("business_products");
                });

            modelBuilder.Entity("Sales_system.Models.BusinessSupplier", b =>
                {
                    b.Property<long>("FkBusinessId")
                        .HasColumnType("bigint")
                        .HasColumnName("fk_business_id");

                    b.Property<long>("FkSupplierId")
                        .HasColumnType("bigint")
                        .HasColumnName("fk_supplier_id");

                    b.HasKey("FkBusinessId", "FkSupplierId")
                        .HasName("business_suppliers_pk_2");

                    b.HasIndex("FkSupplierId");

                    b.HasIndex(new[] { "FkBusinessId", "FkSupplierId" }, "business_suppliers_fk_business_id_fk_supplier_id_index");

                    b.HasIndex(new[] { "FkBusinessId" }, "business_suppliers_pk")
                        .IsUnique();

                    b.ToTable("business_suppliers");
                });

            modelBuilder.Entity("Sales_system.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("client_name");

                    b.HasKey("Id");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("Sales_system.Models.Concept", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<decimal?>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(16, 2)
                        .HasColumnType("numeric(16,2)")
                        .HasColumnName("amount")
                        .HasDefaultValueSql("0.0");

                    b.Property<long>("FkProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("fk_product_id");

                    b.Property<long>("FkSaleId")
                        .HasColumnType("bigint")
                        .HasColumnName("fk_sale_id");

                    b.Property<decimal>("PriceUnit")
                        .HasPrecision(16, 2)
                        .HasColumnType("numeric(16,2)")
                        .HasColumnName("price_unit");

                    b.Property<decimal>("Total")
                        .HasPrecision(16, 2)
                        .HasColumnType("numeric(16,2)")
                        .HasColumnName("total");

                    b.HasKey("Id");

                    b.HasIndex("FkProductId");

                    b.HasIndex("FkSaleId");

                    b.ToTable("concepts");
                });

            modelBuilder.Entity("Sales_system.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<decimal>("Amount")
                        .HasPrecision(16)
                        .HasColumnType("numeric(16)")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("product_name");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(16, 2)
                        .HasColumnType("numeric(16,2)")
                        .HasColumnName("unit_price");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Sales_system.Models.Sale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("FkClientId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_client_id");

                    b.Property<decimal>("Total")
                        .HasPrecision(16, 2)
                        .HasColumnType("numeric(16,2)")
                        .HasColumnName("total");

                    b.HasKey("Id");

                    b.HasIndex("FkClientId");

                    b.HasIndex(new[] { "Id" }, "table_name_id_index");

                    b.ToTable("sales");
                });

            modelBuilder.Entity("Sales_system.Models.Supplier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("email");

                    b.Property<long>("FkUserId")
                        .HasColumnType("bigint")
                        .HasColumnName("fk_user_id");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)")
                        .HasColumnName("phone");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("supplier_name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "FkUserId" }, "suppliers_fk_user_id_index");

                    b.ToTable("suppliers");
                });

            modelBuilder.Entity("Sales_system.Models.SuppliersProduct", b =>
                {
                    b.Property<long>("FkSupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("fk_supplier_id");

                    b.Property<long>("FkProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("fk_product_id");

                    b.HasKey("FkSupplierId", "FkProductId")
                        .HasName("suppliers_products_pk");

                    b.HasIndex("FkProductId");

                    b.HasIndex(new[] { "FkSupplierId", "FkProductId" }, "suppliers_products_fk_supplier_id_fk_product_id_index");

                    b.ToTable("suppliers_products");
                });

            modelBuilder.Entity("Sales_system.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("first_name");

                    b.Property<string>("Surnames")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("surnames");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("user_password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(49)
                        .HasColumnType("character varying(49)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Username" }, "users_username_uindex")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("Sales_system.Models.Business", b =>
                {
                    b.HasOne("Sales_system.Models.User", "FkUser")
                        .WithMany("Businesses")
                        .HasForeignKey("FkUserId")
                        .HasConstraintName("business_users_id_fk")
                        .IsRequired();

                    b.Navigation("FkUser");
                });

            modelBuilder.Entity("Sales_system.Models.BusinessProduct", b =>
                {
                    b.HasOne("Sales_system.Models.Business", "FkBusiness")
                        .WithMany("BusinessProducts")
                        .HasForeignKey("FkBusinessId")
                        .HasConstraintName("business_products_business_id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sales_system.Models.Product", "FkProduct")
                        .WithMany("BusinessProducts")
                        .HasForeignKey("FkProductId")
                        .HasConstraintName("business_products_products_id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FkBusiness");

                    b.Navigation("FkProduct");
                });

            modelBuilder.Entity("Sales_system.Models.BusinessSupplier", b =>
                {
                    b.HasOne("Sales_system.Models.Business", "FkBusiness")
                        .WithOne("BusinessSupplier")
                        .HasForeignKey("Sales_system.Models.BusinessSupplier", "FkBusinessId")
                        .HasConstraintName("business_suppliers_business_id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sales_system.Models.Supplier", "FkSupplier")
                        .WithMany("BusinessSuppliers")
                        .HasForeignKey("FkSupplierId")
                        .HasConstraintName("business_suppliers_suppliers_id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FkBusiness");

                    b.Navigation("FkSupplier");
                });

            modelBuilder.Entity("Sales_system.Models.Concept", b =>
                {
                    b.HasOne("Sales_system.Models.Product", "FkProduct")
                        .WithMany("Concepts")
                        .HasForeignKey("FkProductId")
                        .HasConstraintName("concepts_products_id_fk")
                        .IsRequired();

                    b.HasOne("Sales_system.Models.Sale", "FkSale")
                        .WithMany("Concepts")
                        .HasForeignKey("FkSaleId")
                        .HasConstraintName("concepts_sales_id_fk")
                        .IsRequired();

                    b.Navigation("FkProduct");

                    b.Navigation("FkSale");
                });

            modelBuilder.Entity("Sales_system.Models.Sale", b =>
                {
                    b.HasOne("Sales_system.Models.Client", "FkClient")
                        .WithMany("Sales")
                        .HasForeignKey("FkClientId")
                        .HasConstraintName("sales_clients_id_fk")
                        .IsRequired();

                    b.Navigation("FkClient");
                });

            modelBuilder.Entity("Sales_system.Models.Supplier", b =>
                {
                    b.HasOne("Sales_system.Models.User", "FkUser")
                        .WithMany("Suppliers")
                        .HasForeignKey("FkUserId")
                        .HasConstraintName("suppliers_users_id_fk")
                        .IsRequired();

                    b.Navigation("FkUser");
                });

            modelBuilder.Entity("Sales_system.Models.SuppliersProduct", b =>
                {
                    b.HasOne("Sales_system.Models.Product", "FkProduct")
                        .WithMany("SuppliersProducts")
                        .HasForeignKey("FkProductId")
                        .HasConstraintName("suppliers_products_products_id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sales_system.Models.Supplier", "FkSupplier")
                        .WithMany("SuppliersProducts")
                        .HasForeignKey("FkSupplierId")
                        .HasConstraintName("suppliers_products_suppliers_id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FkProduct");

                    b.Navigation("FkSupplier");
                });

            modelBuilder.Entity("Sales_system.Models.Business", b =>
                {
                    b.Navigation("BusinessProducts");

                    b.Navigation("BusinessSupplier");
                });

            modelBuilder.Entity("Sales_system.Models.Client", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Sales_system.Models.Product", b =>
                {
                    b.Navigation("BusinessProducts");

                    b.Navigation("Concepts");

                    b.Navigation("SuppliersProducts");
                });

            modelBuilder.Entity("Sales_system.Models.Sale", b =>
                {
                    b.Navigation("Concepts");
                });

            modelBuilder.Entity("Sales_system.Models.Supplier", b =>
                {
                    b.Navigation("BusinessSuppliers");

                    b.Navigation("SuppliersProducts");
                });

            modelBuilder.Entity("Sales_system.Models.User", b =>
                {
                    b.Navigation("Businesses");

                    b.Navigation("Suppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
