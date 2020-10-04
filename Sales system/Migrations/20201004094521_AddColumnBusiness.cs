using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales_system.Migrations
{
    public partial class AddColumnBusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "business",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "business");
        }
    }
}
