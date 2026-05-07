namespace DietPlannerAPI.Models
{
    public class DayPlan
    {
        public int Id { get; set; }
        public string DayName { get; set; } = string.Empty;
        public DateTime PlanDate { get; set; }
        public string MealTime { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }

        public int MealId { get; set; }
        public Meal? Meal { get; set; }

        public int? DietPlanId { get; set; }
        public DietPlan? DietPlan { get; set; }
    }
}
