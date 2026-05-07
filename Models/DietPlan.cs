namespace DietPlannerAPI.Models
{
    public class DietPlan
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<DayPlan> DayPlans { get; set; } = new();
    }
}
