namespace DietPlannerAPI.Models
{
    public class WaterIntake
    {
        public int Id { get; set; }
        public DateTime DrinkDate { get; set; }
        public int AmountMl { get; set; }
        public string Notes { get; set; } = string.Empty;

        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
    }
}
