using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webislamdash.Data.Migrations
{
    /// <inheritdoc />
    public partial class Prayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Prayers",
                table: "Prayers");

            migrationBuilder.RenameTable(
                name: "Prayers",
                newName: "Prayer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prayer",
                table: "Prayer",
                column: "PrayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Prayer",
                table: "Prayer");

            migrationBuilder.RenameTable(
                name: "Prayer",
                newName: "Prayers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prayers",
                table: "Prayers",
                column: "PrayerId");
        }
    }
}
