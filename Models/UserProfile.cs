namespace DietPlannerAPI.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public int HeightCm { get; set; }

        public List<BodyMeasurement> BodyMeasurements { get; set; } = new();
        public List<Goal> Goals { get; set; } = new();
        public List<DayPlan> DayPlans { get; set; } = new();
        public List<Appointment> Appointments { get; set; } = new();
        public List<WaterIntake> WaterIntakes { get; set; } = new();
    }
}
