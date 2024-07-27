using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iroh.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUnnecessaryTagAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "App",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Parent",
                table: "Tags");

            migrationBuilder.UpdateData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 26, 17, 19, 19, 628, DateTimeKind.Local).AddTicks(3729));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "App",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Parent",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 26, 17, 13, 41, 697, DateTimeKind.Local).AddTicks(9624));
        }
    }
}
