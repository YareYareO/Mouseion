using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iroh.Migrations
{
    /// <inheritdoc />
    public partial class NameUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Things_Name",
                table: "Things",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Things_Name",
                table: "Things");
        }
    }
}
