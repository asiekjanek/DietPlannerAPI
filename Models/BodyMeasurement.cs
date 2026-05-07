namespace DietPlannerAPI.Models
{
    public class BodyMeasurement
    {
        public int Id { get; set; }
        public decimal WeightKg { get; set; }
        public decimal Bmi { get; set; }
        public DateTime MeasurementDate { get; set; }

        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
    }
}
