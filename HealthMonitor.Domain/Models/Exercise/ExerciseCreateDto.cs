namespace HealthMonitor.Domain.Models.Exercise
{
    public class ExerciseCreateDto
    {
        public string Name { get; set; }
        public string? MuscleTarget { get; set; }
    }
}