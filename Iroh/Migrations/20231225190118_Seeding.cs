using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Iroh.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Things",
                columns: new[] { "Id", "App", "ApplicationUserId", "ApplicationUserId1", "CreatedAt", "Description", "Name", "Upvotes" },
                values: new object[,]
                {
                    { 1, 1, null, null, new DateTime(2023, 12, 25, 20, 1, 18, 84, DateTimeKind.Local).AddTicks(2970), "Funny Spanish guy gets beat up alot of times", "Don Quijote", 0 },
                    { 2, 1, null, null, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crush them enemies", "Niccolo Machiavelli - The Prince", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
