namespace HealthMonitor.Domain.Models.Exercise
{
    public class ExerciseCreateDto
    {
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }
    }
}