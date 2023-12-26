using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iroh.Migrations
{
    /// <inheritdoc />
    public partial class RemoveWrongOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Things_ThingId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Things_AspNetUsers_ApplicationUserId1",
                table: "Things");

            migrationBuilder.DropIndex(
                name: "IX_Things_ApplicationUserId1",
                table: "Things");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ThingId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Things");

            migrationBuilder.DropColumn(
                name: "ThingId",
                table: "Tags");

            migrationBuilder.UpdateData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 26, 11, 38, 37, 542, DateTimeKind.Local).AddTicks(3614));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Things",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThingId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUserId1", "CreatedAt" },
                values: new object[] { null, new DateTime(2023, 12, 25, 20, 1, 18, 84, DateTimeKind.Local).AddTicks(2970) });

            migrationBuilder.UpdateData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationUserId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Things_ApplicationUserId1",
                table: "Things",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ThingId",
                table: "Tags",
                column: "ThingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Things_ThingId",
                table: "Tags",
                column: "ThingId",
                principalTable: "Things",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Things_AspNetUsers_ApplicationUserId1",
                table: "Things",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
