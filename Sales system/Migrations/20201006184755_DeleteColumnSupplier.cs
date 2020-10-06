using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales_system.Migrations
{
    public partial class DeleteColumnSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "suppliers",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "suppliers");
        }
    }
}
