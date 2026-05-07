namespace DietPlannerAPI.Models
{
    public class Dietitian
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;

        public List<TimeSlot> TimeSlots { get; set; } = new();
        public List<Appointment> Appointments { get; set; } = new();
    }
}
