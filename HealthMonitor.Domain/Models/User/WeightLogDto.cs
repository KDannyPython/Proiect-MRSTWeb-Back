namespace HealthMonitor.Domain.Models.User
{
    public class WeightLogDto
    {
        public float Weight { get; set; }
        public DateTime LoggedAt { get; set; }
    }

    public class WeightLogResponseDto
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public DateTime LoggedAt { get; set; }
    }
}
