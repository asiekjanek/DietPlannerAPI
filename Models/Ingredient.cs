namespace DietPlannerAPI.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Calories { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbs { get; set; }
        public decimal Fat { get; set; }
        public decimal Sugar { get; set; }

        public List<MealIngredient> MealIngredients { get; set; } = new();
    }
}
