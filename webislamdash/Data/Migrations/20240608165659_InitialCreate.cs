using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webislamdash.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prayers",
                columns: table => new
                {
                    PrayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrayerTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrayerDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrayerLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prayers", x => x.PrayerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prayers");
        }
    }
}
