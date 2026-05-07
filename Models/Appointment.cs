namespace DietPlannerAPI.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }

        public int DietitianId { get; set; }
        public Dietitian? Dietitian { get; set; }

        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
    }
}
