using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webislamdash.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCityInfosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Bookmarks");

            migrationBuilder.CreateTable(
                name: "CityInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityInfos");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Bookmarks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Prayer",
                columns: table => new
                {
                    PrayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrayerDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrayerLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrayerTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prayer", x => x.PrayerId);
                });
        }
    }
}
