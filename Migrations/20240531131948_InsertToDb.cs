using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Do_an_NMCNPM.Migrations
{
    /// <inheritdoc />
    public partial class InsertToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "ID", "Website_Link" },
                values: new object[] { 1, "https://www.conferenceineurope.org/information_technology.php" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
