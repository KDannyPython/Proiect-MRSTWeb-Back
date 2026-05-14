using HealthMonitor.Domain.Entities.Exercise;
using HealthMonitor.Domain.Entities.Workout;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthMonitor.Domain.Entities.WorkoutExercise
{
    public class WorkoutExercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int WorkoutId { get; set; }

        [ForeignKey("WorkoutId")]
        public Workout.Workout Workout { get; set; } = null!;
        
        [Required]
        public int ExerciseId { get; set; }

        [ForeignKey("ExerciseId")]
        public Exercise.Exercise Exercise { get; set; } = null!;

        [Required]
        [Range(1, 50)]
        public int Sets { get; set; }

        [Required]
        [Range(1, 500)]
        public int Reps { get; set; }

        [Required]
        [Range(0, 550)]
        public float Weight { get; set; }
    }
}