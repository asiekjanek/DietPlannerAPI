using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DietPlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddWaterTracker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WaterIntakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrinkDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountMl = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterIntakes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterIntakes_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WaterIntakes",
                columns: new[] { "Id", "AmountMl", "DrinkDate", "Notes", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 300, new DateTime(2026, 5, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), "Szklanka wody po śniadaniu", 1 },
                    { 2, 500, new DateTime(2026, 5, 11, 13, 30, 0, 0, DateTimeKind.Unspecified), "Woda do obiadu", 1 },
                    { 3, 250, new DateTime(2026, 5, 11, 16, 0, 0, 0, DateTimeKind.Unspecified), "Herbata bez cukru", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaterIntakes_UserProfileId",
                table: "WaterIntakes",
                column: "UserProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaterIntakes");
        }
    }
}
