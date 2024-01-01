using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iroh.Migrations
{
    /// <inheritdoc />
    public partial class Descriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Description",
                table: "Description");

            migrationBuilder.RenameTable(
                name: "Description",
                newName: "Descriptions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Descriptions",
                table: "Descriptions",
                columns: new[] { "ThingId", "TagId" });

            migrationBuilder.UpdateData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 30, 18, 19, 2, 584, DateTimeKind.Local).AddTicks(5665));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Descriptions",
                table: "Descriptions");

            migrationBuilder.RenameTable(
                name: "Descriptions",
                newName: "Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Description",
                table: "Description",
                columns: new[] { "ThingId", "TagId" });

            migrationBuilder.UpdateData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 26, 12, 39, 11, 216, DateTimeKind.Local).AddTicks(5193));
        }
    }
}
