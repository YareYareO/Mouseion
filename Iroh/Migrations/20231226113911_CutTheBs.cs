using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iroh.Migrations
{
    /// <inheritdoc />
    public partial class CutTheBs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Tags_ParentId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Things_AspNetUsers_ApplicationUserId",
                table: "Things");

            migrationBuilder.DropIndex(
                name: "IX_Things_ApplicationUserId",
                table: "Things");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ParentId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Upvote",
                table: "Upvote");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Things");

            migrationBuilder.RenameTable(
                name: "Upvote",
                newName: "Upvotes");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Tags",
                newName: "Parent");

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Things",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Upvotes",
                table: "Upvotes",
                columns: new[] { "UserId", "ThingId" });

            migrationBuilder.CreateTable(
                name: "Description",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false),
                    ThingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Description", x => new { x.ThingId, x.TagId });
                });

            migrationBuilder.UpdateData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Creator" },
                values: new object[] { new DateTime(2023, 12, 26, 12, 39, 11, 216, DateTimeKind.Local).AddTicks(5193), "" });

            migrationBuilder.UpdateData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creator",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Description");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Upvotes",
                table: "Upvotes");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Things");

            migrationBuilder.RenameTable(
                name: "Upvotes",
                newName: "Upvote");

            migrationBuilder.RenameColumn(
                name: "Parent",
                table: "Tags",
                newName: "ParentId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Things",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Upvote",
                table: "Upvote",
                columns: new[] { "UserId", "ThingId" });

            migrationBuilder.UpdateData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "CreatedAt" },
                values: new object[] { null, new DateTime(2023, 12, 26, 12, 24, 0, 998, DateTimeKind.Local).AddTicks(1662) });

            migrationBuilder.UpdateData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Things_ApplicationUserId",
                table: "Things",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ParentId",
                table: "Tags",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Tags_ParentId",
                table: "Tags",
                column: "ParentId",
                principalTable: "Tags",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Things_AspNetUsers_ApplicationUserId",
                table: "Things",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
