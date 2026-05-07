namespace DietPlannerAPI.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int Calories { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbs { get; set; }
        public decimal Fat { get; set; }
        public decimal Sugar { get; set; }

        public List<MealIngredient> MealIngredients { get; set; } = new();
        public List<DayPlan> DayPlans { get; set; } = new();
    }
}
