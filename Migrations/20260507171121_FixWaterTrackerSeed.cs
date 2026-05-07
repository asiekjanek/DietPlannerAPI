using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietPlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixWaterTrackerSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WaterIntakes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DrinkDate", "UserProfileId" },
                values: new object[] { new DateTime(2026, 5, 11, 16, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WaterIntakes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DrinkDate", "UserProfileId" },
                values: new object[] { new DateTime(2026, 5, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), 2 });
        }
    }
}
