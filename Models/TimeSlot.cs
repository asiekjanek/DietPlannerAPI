namespace DietPlannerAPI.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsAvailable { get; set; }

        public int DietitianId { get; set; }
        public Dietitian? Dietitian { get; set; }
    }
}
