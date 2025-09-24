using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Iroh.Migrations
{
    /// <inheritdoc />
    public partial class InitPls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    ThingId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => new { x.ThingId, x.TagId });
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Family = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Things",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    App = table.Column<int>(type: "integer", nullable: false),
                    Upvotes = table.Column<int>(type: "integer", nullable: false),
                    Creator = table.Column<string>(type: "varchar(450)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Things", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Family", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Painting" },
                    { 2, 0, "Sculpture" },
                    { 3, 0, "Theatre Act" },
                    { 4, 1, "Ancient Civilization" },
                    { 5, 1, "Archaeological Site" },
                    { 6, 1, "Battlefield" },
                    { 7, 1, "Building" },
                    { 8, 1, "Landmark" },
                    { 9, 1, "Memorial" },
                    { 10, 1, "Monument" },
                    { 11, 1, "Palace or Castle" },
                    { 12, 1, "Religious Site" },
                    { 13, 1, "Ruins" },
                    { 14, 2, "Activist" },
                    { 15, 2, "Actor" },
                    { 16, 2, "Artist" },
                    { 17, 2, "Athlete" },
                    { 18, 2, "Author" },
                    { 19, 2, "Businessman" },
                    { 20, 2, "Musician" },
                    { 21, 2, "Philosopher" },
                    { 22, 2, "Politician" },
                    { 23, 2, "Scientist" },
                    { 24, 2, "Writer" },
                    { 25, 2, "Ghost" },
                    { 26, 3, "Amphibian" },
                    { 27, 3, "Bird" },
                    { 28, 3, "Insect" },
                    { 29, 3, "Fish" },
                    { 30, 3, "Mammal" },
                    { 31, 3, "Reptile" },
                    { 32, 4, "Battles" },
                    { 33, 4, "Discovery" },
                    { 34, 4, "Holiday" },
                    { 35, 4, "Invention" },
                    { 36, 4, "Natural Disaster" },
                    { 37, 4, "Political Action" },
                    { 38, 4, "Revolution or Civil War" },
                    { 39, 4, "War" },
                    { 40, 4, "Other Event" },
                    { 41, 7, "Anecdote" },
                    { 42, 7, "Article" },
                    { 43, 7, "Book" },
                    { 44, 7, "Essay" },
                    { 45, 7, "Legend" },
                    { 46, 7, "Paper" },
                    { 47, 7, "Poem" },
                    { 48, 7, "Quote" },
                    { 49, 7, "Series of Writings" },
                    { 50, 7, "Tale" },
                    { 51, 7, "Fiction" },
                    { 52, 7, "Non-Fiction" },
                    { 53, 6, "Album" },
                    { 54, 6, "Mixtape" },
                    { 55, 6, "Single" },
                    { 56, 5, "Anime" },
                    { 57, 5, "Movie" },
                    { 58, 5, "Series" },
                    { 59, 5, "Shortmovie" },
                    { 60, 5, "Other Video" },
                    { 61, 8, "Board" },
                    { 62, 8, "Card" },
                    { 63, 8, "Party" },
                    { 64, 8, "Puzzle" },
                    { 65, 10, "Home Utility" },
                    { 66, 10, "Survival" },
                    { 67, 10, "Labor Utility" },
                    { 68, 10, "Electronic" },
                    { 69, 10, "Quality of Life" },
                    { 70, 10, "Universal Utility" },
                    { 71, 10, "Chemical" },
                    { 89, 101, "Archaeology" },
                    { 90, 101, "Astrology:)" },
                    { 91, 101, "Astronomy" },
                    { 92, 101, "Biology" },
                    { 93, 101, "Chemistry" },
                    { 94, 101, "Economy" },
                    { 95, 101, "Neurology" },
                    { 96, 101, "Psychology" },
                    { 97, 101, "Physics" },
                    { 98, 101, "Sociology" },
                    { 99, 102, "Basketball" },
                    { 100, 102, "Car Racing" },
                    { 101, 102, "Esports" },
                    { 102, 102, "Football" },
                    { 103, 102, "Martial Arts" },
                    { 104, 102, "Rugby or American Football" },
                    { 105, 102, "Running" },
                    { 106, 102, "Swimming" },
                    { 107, 102, "Tennis" },
                    { 108, 102, "Volleyball" },
                    { 109, 102, "Weightlifting" },
                    { 110, 102, "Other Sport" },
                    { 111, 100, "About Children" },
                    { 112, 100, "Advice" },
                    { 113, 100, "Art or Photography" },
                    { 114, 100, "Biography" },
                    { 115, 100, "Commentary" },
                    { 116, 100, "Documentary" },
                    { 117, 100, "Finance" },
                    { 118, 100, "Guide" },
                    { 119, 100, "Memoir" },
                    { 120, 100, "Parenting" },
                    { 121, 100, "Past Civilization" },
                    { 122, 100, "Philosophy" },
                    { 123, 100, "Political" },
                    { 124, 100, "Self-Help" },
                    { 125, 100, "Personal Relationship" },
                    { 126, 100, "Religion" },
                    { 127, 100, "Technology" },
                    { 128, 100, "True Crime" },
                    { 129, 103, "Action" },
                    { 130, 103, "Adventure" },
                    { 131, 103, "Crime" },
                    { 132, 103, "Drama" },
                    { 133, 103, "Dystopian" },
                    { 134, 103, "Fantasy" },
                    { 135, 103, "Historical" },
                    { 136, 103, "Horror" },
                    { 137, 103, "Mystery" },
                    { 138, 103, "Noir" },
                    { 139, 103, "Romance" },
                    { 140, 103, "Satire" },
                    { 141, 103, "Science Fiction" },
                    { 142, 103, "Seinen" },
                    { 143, 103, "Shoji" },
                    { 144, 103, "Shonen" },
                    { 145, 103, "Swashbuckle" },
                    { 146, 103, "Thriller" },
                    { 147, 104, "Fun or Comedy" },
                    { 148, 104, "Indie" },
                    { 149, 104, "Safe For Children" },
                    { 150, 104, "Was Banned Somewhere" },
                    { 151, 105, "Classical" },
                    { 152, 105, "Electronic" },
                    { 153, 105, "Hip-Hop" },
                    { 154, 105, "Jazz" },
                    { 155, 105, "Metal" },
                    { 156, 105, "Pop" },
                    { 157, 105, "Reggae" },
                    { 158, 105, "R&B" },
                    { 159, 105, "Rock" },
                    { 160, 105, "Soundtrack" },
                    { 161, 106, "2D" },
                    { 162, 106, "3D" },
                    { 163, 106, "Action" },
                    { 164, 106, "Puzzle" },
                    { 165, 106, "Multiplayer" },
                    { 166, 106, "RPG" },
                    { 167, 106, "Simulation" },
                    { 168, 106, "Shooter" },
                    { 169, 106, "Sandbox" },
                    { 900, 200, "Europe" },
                    { 901, 200, "Africa" },
                    { 902, 200, "Asia" },
                    { 903, 200, "Middle East" },
                    { 904, 200, "North America" },
                    { 905, 200, "Oceania" },
                    { 906, 200, "Ocean" },
                    { 907, 200, "South America" },
                    { 908, 201, "21th Century" },
                    { 909, 201, "20th Century" },
                    { 910, 201, "19th Century" },
                    { 911, 201, "18th Century" },
                    { 912, 201, "17th Century" },
                    { 913, 201, "16th Century" },
                    { 914, 201, "5th to 15th Century" },
                    { 915, 201, "Ancient to 4th Century" },
                    { 916, 201, "Pre Historic" },
                    { 917, 202, "Factual" },
                    { 918, 202, "Fictional" },
                    { 919, 202, "Mythological" },
                    { 920, 202, "Religious" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Things_Name",
                table: "Things",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Things");
        }
    }
}
