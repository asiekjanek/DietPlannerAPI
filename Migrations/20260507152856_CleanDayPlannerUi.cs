using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DietPlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class CleanDayPlannerUi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Drugie śniadanie" },
                    { 5, "Lunch" },
                    { 6, "Podwieczorek" },
                    { 7, "Przekąska" }
                });

            migrationBuilder.UpdateData(
                table: "DayPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DietPlanId", "MealTime", "PlanDate" },
                values: new object[] { null, "Śniadanie", new DateTime(2026, 5, 11, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DayPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DietPlanId", "MealTime", "PlanDate" },
                values: new object[] { null, "Obiad", new DateTime(2026, 5, 11, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DayPlans",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DietPlanId", "MealTime", "PlanDate" },
                values: new object[] { null, "Kolacja", new DateTime(2026, 5, 12, 18, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "DayPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DietPlanId", "MealTime", "PlanDate" },
                values: new object[] { 1, "08:00 Śniadanie", new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DayPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DietPlanId", "MealTime", "PlanDate" },
                values: new object[] { 1, "13:00 Obiad", new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DayPlans",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DietPlanId", "MealTime", "PlanDate" },
                values: new object[] { 2, "18:00 Kolacja", new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
