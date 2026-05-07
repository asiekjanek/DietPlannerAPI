using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietPlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDayPlannerAndMacros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayPlans_DietPlans_DietPlanId",
                table: "DayPlans");

            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Carbs",
                table: "Meals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Fat",
                table: "Meals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Protein",
                table: "Meals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Sugar",
                table: "Meals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Carbs",
                table: "Ingredients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Fat",
                table: "Ingredients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Protein",
                table: "Ingredients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Sugar",
                table: "Ingredients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "DietPlanId",
                table: "DayPlans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "DayPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MealTime",
                table: "DayPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "DayPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PlanDate",
                table: "DayPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "DayPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DayPlans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MealId", "MealTime", "Notes", "PlanDate", "UserProfileId" },
                values: new object[] { 1, "08:00 Śniadanie", "Bez dodatkowego cukru", new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "DayPlans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DayName", "MealId", "MealTime", "Notes", "PlanDate", "UserProfileId" },
                values: new object[] { "Poniedziałek", 2, "13:00 Obiad", "Dodać więcej warzyw", new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "DayPlans",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DayName", "MealId", "MealTime", "Notes", "PlanDate", "UserProfileId" },
                values: new object[] { "Wtorek", 3, "18:00 Kolacja", "Lekka kolacja po spacerze", new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Carbs", "Fat", "Protein", "Sugar" },
                values: new object[] { 60m, 7m, 13m, 1m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Carbs", "Fat", "Protein", "Sugar" },
                values: new object[] { 23m, 0m, 1m, 12m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Carbs", "Fat", "Protein", "Sugar" },
                values: new object[] { 0m, 4m, 31m, 0m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Carbs", "Fat", "Protein", "Sugar" },
                values: new object[] { 3m, 0m, 1m, 1m });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Carbs", "Fat", "Protein", "Sugar" },
                values: new object[] { 3m, 5m, 11m, 3m });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Calories", "Carbs", "Fat", "Protein", "Sugar" },
                values: new object[] { 420, 62m, 10m, 18m, 18m });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Calories", "Carbs", "Fat", "Protein", "Sugar" },
                values: new object[] { 560, 28m, 25m, 42m, 8m });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Calories", "Carbs", "Fat", "Protein", "Sugar" },
                values: new object[] { 390, 48m, 12m, 24m, 6m });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Age", "FullName", "Gender", "HeightCm" },
                values: new object[] { 2, 72, "Babcia Maria", "Kobieta", 164 });

            migrationBuilder.InsertData(
                table: "BodyMeasurements",
                columns: new[] { "Id", "Bmi", "MeasurementDate", "UserProfileId", "WeightKg" },
                values: new object[] { 3, 25.4m, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 68.2m });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "Id", "Description", "GoalType", "TargetWeightKg", "UserProfileId" },
                values: new object[] { 2, "Regularne posiłki i ograniczenie cukru.", "Zdrowsze odżywianie", 66.0m, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_DayPlans_MealId",
                table: "DayPlans",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_DayPlans_UserProfileId",
                table: "DayPlans",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserProfileId",
                table: "Appointments",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_UserProfiles_UserProfileId",
                table: "Appointments",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayPlans_DietPlans_DietPlanId",
                table: "DayPlans",
                column: "DietPlanId",
                principalTable: "DietPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DayPlans_Meals_MealId",
                table: "DayPlans",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayPlans_UserProfiles_UserProfileId",
                table: "DayPlans",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_UserProfiles_UserProfileId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_DayPlans_DietPlans_DietPlanId",
                table: "DayPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_DayPlans_Meals_MealId",
                table: "DayPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_DayPlans_UserProfiles_UserProfileId",
                table: "DayPlans");

            migrationBuilder.DropIndex(
                name: "IX_DayPlans_MealId",
                table: "DayPlans");

            migrationBuilder.DropIndex(
                name: "IX_DayPlans_UserProfileId",
                table: "DayPlans");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_UserProfileId",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "BodyMeasurements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Sugar",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Sugar",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "DayPlans");

            migrationBuilder.DropColumn(
                name: "MealTime",
                table: "DayPlans");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "DayPlans");

            migrationBuilder.DropColumn(
                name: "PlanDate",
                table: "DayPlans");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "DayPlans");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "DietPlanId",
                table: "DayPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DayPlans",
                keyColumn: "Id",
                keyValue: 2,
                column: "DayName",
                value: "Wtorek");

            migrationBuilder.UpdateData(
                table: "DayPlans",
                keyColumn: "Id",
                keyValue: 3,
                column: "DayName",
                value: "Środa");

            migrationBuilder.AddForeignKey(
                name: "FK_DayPlans_DietPlans_DietPlanId",
                table: "DayPlans",
                column: "DietPlanId",
                principalTable: "DietPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
