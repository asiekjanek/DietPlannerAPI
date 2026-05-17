using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DietPlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreAvailableTimeSlots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAvailable",
                value: false);

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "DietitianId", "IsAvailable", "StartTime" },
                values: new object[,]
                {
                    { 4, 1, true, new DateTime(2026, 5, 12, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, true, new DateTime(2026, 5, 12, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, true, new DateTime(2026, 5, 13, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, true, new DateTime(2026, 5, 14, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, true, new DateTime(2026, 5, 15, 9, 30, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAvailable",
                value: true);
        }
    }
}
