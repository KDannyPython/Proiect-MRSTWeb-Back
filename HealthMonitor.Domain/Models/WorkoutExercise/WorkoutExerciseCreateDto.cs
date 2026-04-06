namespace HealthMonitor.Domain.Models.WorkoutExercise
{
    public class WorkoutExerciseCreateDto
    {
        public int ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }
    }
}
