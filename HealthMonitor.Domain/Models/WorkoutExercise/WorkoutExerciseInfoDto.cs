namespace HealthMonitor.Domain.Models.WorkoutExercise
{
    public class WorkoutExerciseInfoDto
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public string MuscleTarget { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }
    }
}
