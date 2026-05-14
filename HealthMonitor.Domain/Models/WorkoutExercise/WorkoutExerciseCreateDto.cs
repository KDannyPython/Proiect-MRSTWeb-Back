using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.WorkoutExercise
{
    public class WorkoutExerciseCreateDto
    {
        [Required]
        public int ExerciseId { get; set; }
        
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
