using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Entities.Exercise
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(50)]
        public string? MuscleTarget { get; set; }

        public List<WorkoutExercise.WorkoutExercise> WorkoutExercises { get; set; } =
        new List<WorkoutExercise.WorkoutExercise>();
    }
}
    