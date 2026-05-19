namespace DietPlannerAPI.Models
{
    public class HabitCompletion
    {
        public int Id { get; set; }
        public DateTime CompletionDate { get; set; }

        public int GoalId { get; set; }
        public Goal? Goal { get; set; }
    }
}
