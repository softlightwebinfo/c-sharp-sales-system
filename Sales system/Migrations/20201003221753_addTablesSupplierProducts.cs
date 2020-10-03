using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales_system.Migrations
{
    public partial class addTablesSupplierProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "suppliers_products",
                columns: table => new
                {
                    fk_supplier_id = table.Column<long>(type: "bigint", nullable: false),
                    fk_product_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("suppliers_products_pk", x => new { x.fk_supplier_id, x.fk_product_id });
                    table.ForeignKey(
                        name: "suppliers_products_products_id_fk",
                        column: x => x.fk_product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "suppliers_products_suppliers_id_fk",
                        column: x => x.fk_supplier_id,
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_products_fk_product_id",
                table: "suppliers_products",
                column: "fk_product_id");

            migrationBuilder.CreateIndex(
                name: "suppliers_products_fk_supplier_id_fk_product_id_index",
                table: "suppliers_products",
                columns: new[] { "fk_supplier_id", "fk_product_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "suppliers_products");
        }
    }
}
