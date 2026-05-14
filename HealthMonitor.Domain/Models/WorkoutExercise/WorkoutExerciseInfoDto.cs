using HealthMonitor.Domain.Entities.Exercise;

namespace HealthMonitor.Domain.Models.WorkoutExercise
{
    public class WorkoutExerciseInfoDto
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; } = null!;
        public MuscleGroup PrimaryMuscleGroup { get; set; }
        public string? SecondaryMuscleGroup { get; set; }
        public Difficulty Difficulty { get; set; }
        public FatigueCost FatigueCost { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }
    }
}
