using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietPlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAnnaKaloszEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "kaloszkaaa@gmail.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "anna.kalosz@gmail.com");
        }
    }
}
