using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sales_system.Migrations
{
    public partial class addTablesBussinesProductsAndSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "business_products",
                columns: table => new
                {
                    fk_business_id = table.Column<long>(type: "bigint", nullable: false),
                    fk_product_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("business_products_pk", x => new { x.fk_business_id, x.fk_product_id });
                    table.ForeignKey(
                        name: "business_products_business_id_fk",
                        column: x => x.fk_business_id,
                        principalTable: "business",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "business_products_products_id_fk",
                        column: x => x.fk_product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    supplier_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    fk_user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.id);
                    table.ForeignKey(
                        name: "suppliers_users_id_fk",
                        column: x => x.fk_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "business_suppliers",
                columns: table => new
                {
                    fk_business_id = table.Column<long>(type: "bigint", nullable: false),
                    fk_supplier_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("business_suppliers_pk_2", x => new { x.fk_business_id, x.fk_supplier_id });
                    table.ForeignKey(
                        name: "business_suppliers_business_id_fk",
                        column: x => x.fk_business_id,
                        principalTable: "business",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "business_suppliers_suppliers_id_fk",
                        column: x => x.fk_supplier_id,
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "business_products_fk_business_id_fk_product_id_index",
                table: "business_products",
                columns: new[] { "fk_business_id", "fk_product_id" });

            migrationBuilder.CreateIndex(
                name: "IX_business_products_fk_product_id",
                table: "business_products",
                column: "fk_product_id");

            migrationBuilder.CreateIndex(
                name: "business_suppliers_fk_business_id_fk_supplier_id_index",
                table: "business_suppliers",
                columns: new[] { "fk_business_id", "fk_supplier_id" });

            migrationBuilder.CreateIndex(
                name: "business_suppliers_pk",
                table: "business_suppliers",
                column: "fk_business_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_business_suppliers_fk_supplier_id",
                table: "business_suppliers",
                column: "fk_supplier_id");

            migrationBuilder.CreateIndex(
                name: "suppliers_fk_user_id_index",
                table: "suppliers",
                column: "fk_user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "business_products");

            migrationBuilder.DropTable(
                name: "business_suppliers");

            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}
