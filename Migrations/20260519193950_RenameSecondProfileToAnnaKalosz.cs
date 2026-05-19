using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietPlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameSecondProfileToAnnaKalosz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "Email", "FullName", "HeightCm" },
                values: new object[] { 26, "anna.kalosz@gmail.com", "Anna Kalosz", 170 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "Email", "FullName", "HeightCm" },
                values: new object[] { 72, "maria.babcia@gmail.com", "Babcia Maria", 164 });
        }
    }
}
