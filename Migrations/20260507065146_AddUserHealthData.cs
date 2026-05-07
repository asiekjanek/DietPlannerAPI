using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DietPlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserHealthData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    HeightCm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BodyMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bmi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyMeasurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodyMeasurements_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetWeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goals_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Age", "FullName", "Gender", "HeightCm" },
                values: new object[] { 1, 28, "Jan Testowy", "Mężczyzna", 178 });

            migrationBuilder.InsertData(
                table: "BodyMeasurements",
                columns: new[] { "Id", "Bmi", "MeasurementDate", "UserProfileId", "WeightKg" },
                values: new object[,]
                {
                    { 1, 26.0m, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 82.5m },
                    { 2, 25.8m, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 81.8m }
                });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "Id", "Description", "GoalType", "TargetWeightKg", "UserProfileId" },
                values: new object[] { 1, "Stopniowa redukcja masy ciała przy zachowaniu zdrowych nawyków.", "Redukcja", 76.0m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurements_UserProfileId",
                table: "BodyMeasurements",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_UserProfileId",
                table: "Goals",
                column: "UserProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyMeasurements");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
