using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietPlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMealIngredientQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "QuantityGrams",
                table: "MealIngredients",
                type: "decimal(8,2)",
                precision: 8,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "MealIngredients",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 1, 1 },
                column: "QuantityGrams",
                value: 70m);

            migrationBuilder.UpdateData(
                table: "MealIngredients",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 2, 1 },
                column: "QuantityGrams",
                value: 120m);

            migrationBuilder.UpdateData(
                table: "MealIngredients",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 3, 2 },
                column: "QuantityGrams",
                value: 150m);

            migrationBuilder.UpdateData(
                table: "MealIngredients",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 4, 2 },
                column: "QuantityGrams",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "MealIngredients",
                keyColumns: new[] { "IngredientId", "MealId" },
                keyValues: new object[] { 5, 3 },
                column: "QuantityGrams",
                value: 120m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityGrams",
                table: "MealIngredients");
        }
    }
}
