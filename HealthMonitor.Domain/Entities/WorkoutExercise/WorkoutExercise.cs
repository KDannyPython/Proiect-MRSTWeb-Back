using HealthMonitor.Domain.Entities.Exercise;
using HealthMonitor.Domain.Entities.Workout;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Entities.WorkoutExercise
{
    public class WorkoutExercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int WorkoutId { get; set; }

        [Required]
        public int ExerciseId { get; set; }

        [Required]
        [Range(1, 50)]
        public int Sets { get; set; }

        [Required]
        [Range(1, 500)]
        public int Reps { get; set; }

        [Required]
        [Range(0, 500)]
        public float Weight { get; set; }

        public Workout.Workout Workout { get; set; }
        public Exercise.Exercise Exercise { get; set; }
    }
}