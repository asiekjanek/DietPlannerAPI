namespace DietPlannerAPI.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string GoalType { get; set; } = string.Empty;
        public decimal TargetWeightKg { get; set; }
        public string Description { get; set; } = string.Empty;

        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
    }
}
