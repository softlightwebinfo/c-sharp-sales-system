using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales_system.Migrations
{
    public partial class ModifyColumnsDateClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "clients",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "now()");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "clients",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "clients",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "now()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "clients");
        }
    }
}
