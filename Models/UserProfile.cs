namespace DietPlannerAPI.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string AccessCode { get; set; } = "1234";
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public int HeightCm { get; set; }
        public int DailyCalorieGoal { get; set; } = 2000;
        public int DailyWaterGoalMl { get; set; } = 2000;

        public List<BodyMeasurement> BodyMeasurements { get; set; } = new();
        public List<Goal> Goals { get; set; } = new();
        public List<DayPlan> DayPlans { get; set; } = new();
        public List<Appointment> Appointments { get; set; } = new();
        public List<WaterIntake> WaterIntakes { get; set; } = new();
    }
}
