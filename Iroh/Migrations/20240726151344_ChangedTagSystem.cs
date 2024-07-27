using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iroh.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTagSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagType",
                table: "Tags",
                newName: "Family");

            migrationBuilder.UpdateData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "App", "CreatedAt" },
                values: new object[] { 7, new DateTime(2024, 7, 26, 17, 13, 41, 697, DateTimeKind.Local).AddTicks(9624) });

            migrationBuilder.UpdateData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 2,
                column: "App",
                value: 7);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Family",
                table: "Tags",
                newName: "TagType");

            migrationBuilder.UpdateData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "App", "CreatedAt" },
                values: new object[] { 1, new DateTime(2023, 12, 30, 18, 19, 2, 584, DateTimeKind.Local).AddTicks(5665) });

            migrationBuilder.UpdateData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 2,
                column: "App",
                value: 1);
        }
    }
}
